using System;
namespace MojaPasieka.cqrs
{
	public interface IConsumer
	{
		void Handle(IEvent eventMessage);
	}
}
