using System;
using System.Threading.Tasks;
using MojaPasieka.DataModel;
using SQLite;

namespace MojaPasieka.cqrs
{
	public class AddBeeHiveBodyHandler : CommandHandlerBase, ICommandHandlerAsync<AddBeeHiveBody>
	{

		public async Task HandleAsync(AddBeeHiveBody command)
		{
			Connection.Insert(command.Body);
			await EventPublisher.PublishAsync<Event<BeeHiveBody>>(new Event<BeeHiveBody>(command.Body, EventAction.CREATE));
		}
	}
}
