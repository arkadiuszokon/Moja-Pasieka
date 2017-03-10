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

		private static Dictionary<Type, List<object>> _consumersAsync = new Dictionary<Type, List<object>>();

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

		public void RegisterAsyncConsumer<TEvent>(IConsumerAsync<TEvent> consumer) where TEvent : IEvent
		{
			List<object> current;
			if (_consumersAsync.TryGetValue(typeof(TEvent), out current))
			{
				if (!current.Exists((obj) => obj == consumer))
				{
					current.Add(consumer);
				}
			}
			else
			{
				_consumersAsync.Add(typeof(TEvent), new List<object> {consumer});
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


	}
}
