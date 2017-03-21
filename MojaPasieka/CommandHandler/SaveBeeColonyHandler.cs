using System;
using System.Threading.Tasks;
using MojaPasieka.DataModel;
namespace MojaPasieka.cqrs
{
	public class SaveBeeColonyHandler : CommandHandlerBase, ICommandHandlerAsync<SaveBeeColony>
	{
		public async Task HandleAsync(SaveBeeColony command)
		{
			if (command.Colony.bc_id == 0)
			{
				Connection.Insert(command.Colony, typeof(BeeColony));
				await EventPublisher.PublishAsync<Event<BeeColony>>(new Event<BeeColony>(command.Colony, EventAction.CREATE));
			}
			else
			{
				Connection.Update(command.Colony, typeof(BeeColony));
				await EventPublisher.PublishAsync<Event<BeeColony>>(new Event<BeeColony>(command.Colony, EventAction.UPDATE));
			}

		}
	}
}
