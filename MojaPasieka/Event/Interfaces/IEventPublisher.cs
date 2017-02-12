using System;
using System.Threading.Tasks;

namespace MojaPasieka.cqrs
{
	public interface IEventPublisher
	{
		void Publish<TEvent>(TEvent @event) where TEvent : IEvent;
		Task PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent;
	}
}
