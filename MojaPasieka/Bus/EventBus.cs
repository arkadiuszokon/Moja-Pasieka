using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Reflection;
using Autofac;
using MojaPasieka.cqrs;
using System.Diagnostics;

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
			List<object> consumers;
			if (_consumers.TryGetValue(@event.GetType(), out consumers))
			{
				foreach (var consumer in consumers)
				{
					if (consumer is IConsumer<TEvent>)
					{
						(consumer as IConsumer<TEvent>).Handle(@event);
					}

				}
			}
		}

		public async Task PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent
		{
			
			List<object> consumers;
			if (_consumersAsync.TryGetValue(typeof(TEvent), out consumers))
			{
				foreach (var consumer in consumers)
				{
					if (consumer is IConsumerAsync<TEvent>)
					{
						await (consumer as IConsumerAsync<TEvent>).HandleAsync(@event);
					}
				}
			}
		}

		private static Dictionary<Type, List<object>> _consumers = new Dictionary<Type, List<object>>();
		private static Dictionary<Type, List<object>> _consumersAsync = new Dictionary<Type, List<object>>();


		public void RegisterAsyncConsumer<TEvent>(IConsumerAsync<TEvent> consumer) where TEvent : IEvent
		{
			List<object> current;
			if (_consumersAsync.TryGetValue(typeof(TEvent), out current))
			{
				current.Add(consumer);
			}
			else
			{
				_consumersAsync.Add(typeof(TEvent), new List<object> {consumer});
			}
		}

		public void RegisterConsumer<TEvent>(IConsumer<TEvent> consumer) where TEvent : IEvent
		{
			List<object> current;
			if (_consumers.TryGetValue(typeof(TEvent), out current))
			{
				current.Add(consumer);
			}
			else
			{
				_consumers.Add(typeof(TEvent), new List<object> { consumer });
			}
		}

		public void UnregisterAsyncConsumer<TEvent>(IConsumerAsync<TEvent> consumer) where TEvent : IEvent
		{
			List<object> current;
			if (_consumersAsync.TryGetValue(typeof(TEvent), out current))
			{
				current.Remove(consumer);
			}
		}

		public void UnregisterConsumer<TEvent>(IConsumer<TEvent> consumer) where TEvent : IEvent
		{
			List<object> current;
			if (_consumers.TryGetValue(typeof(TEvent), out current))
			{
				current.Remove(consumer);
			}
		}
	}
}
