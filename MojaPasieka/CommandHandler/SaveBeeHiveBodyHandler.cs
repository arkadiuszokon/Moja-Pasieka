using System;
using System.Threading.Tasks;
using MojaPasieka.DataModel;
using SQLite;

namespace MojaPasieka.cqrs
{
	public class SaveBeeHiveBodyHandler : CommandHandlerBase, ICommandHandlerAsync<SaveBeeHiveBody>
	{

		public async Task HandleAsync(SaveBeeHiveBody command)
		{
			if (command.Body.bhb_id == 0)
			{
				Connection.Insert(command.Body, typeof(BeeHiveBody));
				await EventPublisher.PublishAsync<Event<BeeHiveBody>>(new Event<BeeHiveBody>(command.Body, EventAction.CREATE));
			}
			else
			{
				Connection.Update(command.Body, typeof(BeeHiveBody));
				await EventPublisher.PublishAsync<Event<BeeHiveBody>>(new Event<BeeHiveBody>(command.Body, EventAction.UPDATE));
			}

		}
	}
}
