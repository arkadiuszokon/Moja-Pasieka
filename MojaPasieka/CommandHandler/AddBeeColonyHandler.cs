using System;
using System.Threading.Tasks;
using MojaPasieka.DataModel;
namespace MojaPasieka.cqrs
{
	public class AddBeeColonyHandler : CommandHandlerBase, ICommandHandlerAsync<AddBeeColony>
	{
		public async Task HandleAsync(AddBeeColony command)
		{
			Connection.Insert(command.Colony);
			await EventPublisher.PublishAsync<Event<BeeColony>>(new Event<BeeColony>(command.Colony, EventAction.CREATE));
		}
	}
}
