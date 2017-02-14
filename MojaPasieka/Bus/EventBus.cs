using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Autofac;

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
			var subscriptions = _resolver.Resolve<IEnumerable<IConsumer<TEvent>>>();

			foreach (var subsription in subscriptions)
			{
				subsription.Handle(@event);
			}

		}

		public async Task PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent
		{
			var subscriptions = _resolver.Resolve<IEnumerable<IConsumerAsync<TEvent>>>();

			foreach (var subsription in subscriptions)
			{
				await subsription.HandleAsync(@event);
			}
		}
	}
}
