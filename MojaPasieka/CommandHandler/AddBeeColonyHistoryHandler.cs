using System;
using System.Threading.Tasks;
using MojaPasieka.DataModel;

namespace MojaPasieka.cqrs
{
	public class AddBeeColonyHistoryHandler : CommandHandlerBase, ICommandHandlerAsync<AddBeeColonyHistory>
	{
		public async Task HandleAsync(AddBeeColonyHistory command)
		{
			Connection.Insert(command.ColonyHistory);
			await EventPublisher.PublishAsync<Event<BeeColonyHistory>>(new Event<BeeColonyHistory>(command.ColonyHistory, EventAction.CREATE));
		}
	}
}
