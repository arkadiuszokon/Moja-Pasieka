using System;
using System.Threading.Tasks;
using MojaPasieka.DataModel;

namespace MojaPasieka.cqrs
{
	public class SaveBeeColonyHistoryHandler : CommandHandlerBase, ICommandHandlerAsync<SaveBeeColonyHistory>
	{
		public async Task HandleAsync(SaveBeeColonyHistory command)
		{
			if (command.ColonyHistory.bch_id == 0)
			{
				Connection.Insert(command.ColonyHistory, typeof(BeeColonyHistory));
				await EventPublisher.PublishAsync<Event<BeeColonyHistory>>(new Event<BeeColonyHistory>(command.ColonyHistory, EventAction.CREATE));
			}
			else
			{
				Connection.Update(command.ColonyHistory, typeof(BeeColonyHistory));
				await EventPublisher.PublishAsync<Event<BeeColonyHistory>>(new Event<BeeColonyHistory>(command.ColonyHistory, EventAction.UPDATE));
			}
		}
	}
}
