using System;
using System.Threading.Tasks;
using MojaPasieka.DataModel;
namespace MojaPasieka.cqrs
{
	public class AddQueenBeeHandler : CommandHandlerBase, ICommandHandlerAsync<AddQueenBee>
	{
		public async Task HandleAsync(AddQueenBee command)
		{
			Connection.Insert(command.Queen);
			await EventPublisher.PublishAsync<Event<QueenBee>>(new Event<QueenBee>(command.Queen, EventAction.CREATE));
		}
	}
}
