using System;
using System.Threading.Tasks;
using MojaPasieka.DataModel;
namespace MojaPasieka.cqrs
{
	public class SaveQueenBeeHandler : CommandHandlerBase, ICommandHandlerAsync<SaveQueenBee>
	{
		public async Task HandleAsync(SaveQueenBee command)
		{
			if (command.Queen.qb_id == 0)
			{
				Connection.Insert(command.Queen, typeof(QueenBee));
				await EventPublisher.PublishAsync<Event<QueenBee>>(new Event<QueenBee>(command.Queen, EventAction.CREATE));
			}
			else
			{
				Connection.Update(command.Queen, typeof(QueenBee));
				await EventPublisher.PublishAsync<Event<QueenBee>>(new Event<QueenBee>(command.Queen, EventAction.UPDATE));
			}
		}
	}
}
