using System;
namespace MojaPasieka.cqrs
{
	public interface IConsumer<TEvent> where TEvent : IEvent
	{
		void Handle(TEvent eventMessage);
	}
}
