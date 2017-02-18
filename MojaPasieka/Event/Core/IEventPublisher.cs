using System;
using System.Threading.Tasks;

namespace MojaPasieka.cqrs
{
	public interface IEventPublisher
	{
		void Publish<TEvent>(TEvent @event) where TEvent : IEvent;
		Task PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent;

		void RegisterConsumer<TEvent>(IConsumer<TEvent> consumer) where TEvent : IEvent; 
		void UnregisterConsumer<TEvent>(IConsumer<TEvent> consumer) where TEvent : IEvent;

		void RegisterAsyncConsumer<TEvent>(IConsumerAsync<TEvent> consumer) where TEvent : IEvent;
		void UnregisterAsyncConsumer<TEvent>(IConsumerAsync<TEvent> consumer) where TEvent : IEvent;

	}
}
