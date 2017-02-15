using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Reflection;
using Autofac;
using MojaPasieka.cqrs;

namespace MojaPasieka.cqrs
{
	public class EventBus : IEventPublisher
	{
		private readonly ILifetimeScope _resolver;

		public EventBus(ILifetimeScope resolver)
		{
			_resolver = resolver;
		}

		public void Publish<TEvent>(TEvent @event) where TEvent : IEvent
		{
			List<IConsumer> consumers;
			if (_consumers.TryGetValue(@event.GetType(), out consumers))
			{
				foreach (var consumer in consumers)
				{
					consumer.Handle(@event);
				}
			}
		}

		public async Task PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent
		{
			List<IConsumerAsync> consumers;
			if (_consumersAsync.TryGetValue(@event.GetType(), out consumers))
			{
				foreach (var consumer in consumers)
				{
					await consumer.HandleAsync(@event);
				}
			}
		}

		private static Dictionary<Type, List<IConsumer>> _consumers = new Dictionary<Type, List<IConsumer>>();
		private static Dictionary<Type, List<IConsumerAsync>> _consumersAsync = new Dictionary<Type, List<IConsumerAsync>>();

		public void RegisterAsyncConsumer<TEvent>(IConsumerAsync consumer) where TEvent : IEvent
		{
			List<IConsumerAsync> current;
			if (_consumersAsync.TryGetValue(typeof(TEvent), out current))
			{
				current.Add(consumer);
			}
			else
			{
				_consumersAsync.Add(typeof(TEvent), new List<IConsumerAsync> {consumer});
			}
		}

		public void RegisterConsumer<TEvent>(IConsumer consumer) where TEvent : IEvent
		{
			List<IConsumer> current;
			if (_consumers.TryGetValue(typeof(TEvent), out current))
			{
				current.Add((consumer as IConsumer));
			}
			else
			{
				_consumers.Add(typeof(TEvent), new List<IConsumer> { consumer });
			}
		}

		public void UnregisterAsyncConsumer<TEvent>(IConsumerAsync consumer) where TEvent : IEvent
		{
			List<IConsumerAsync> current;
			if (_consumersAsync.TryGetValue(typeof(TEvent), out current))
			{
				current.Remove(consumer);
			}
		}

		public void UnregisterConsumer<TEvent>(IConsumer consumer) where TEvent : IEvent
		{
			List<IConsumer> current;
			if (_consumers.TryGetValue(typeof(TEvent), out current))
			{
				current.Remove(consumer);
			}
		}
	}
}
