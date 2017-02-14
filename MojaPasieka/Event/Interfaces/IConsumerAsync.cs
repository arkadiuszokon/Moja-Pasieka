using System;
using System.Threading.Tasks;

namespace MojaPasieka.cqrs
{
	public interface IConsumerAsync<TEvent> where TEvent : IEvent
	{
		Task HandleAsync(TEvent eventMessage);
	}

}
