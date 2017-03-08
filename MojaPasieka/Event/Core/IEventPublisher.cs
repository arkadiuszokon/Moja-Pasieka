using System;
using System.Threading.Tasks;

namespace MojaPasieka.cqrs
{
	public interface IEventPublisher
	{
		Task PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent;
		void RegisterAsyncConsumer<TEvent>(IConsumerAsync<TEvent> consumer) where TEvent : IEvent;
		void UnregisterAsyncConsumer<TEvent>(IConsumerAsync<TEvent> consumer) where TEvent : IEvent;
	}
}
