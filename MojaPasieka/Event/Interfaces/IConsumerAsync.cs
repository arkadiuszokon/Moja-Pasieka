using System;
using System.Threading.Tasks;

namespace MojaPasieka.cqrs
{
	public interface IConsumerAsync
	{
		Task HandleAsync(IEvent eventMessage);
	}

}
