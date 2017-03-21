using System;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using MojaPasieka.DataModel;
using System.Diagnostics;

namespace MojaPasieka.cqrs
{
	public class SaveBeeHiveHandler : CommandHandlerBase, ICommandHandlerAsync<SaveBeeHive>
	{
		public async Task HandleAsync(SaveBeeHive command)
		{
			if (command.BeeHive.bh_id == 0)
			{
				Connection.Insert(command.BeeHive, typeof(BeeHive));
				await EventPublisher.PublishAsync<Event<BeeHive>>(new Event<BeeHive>(command.BeeHive, EventAction.CREATE));
			}
			else
			{
				Connection.Update(command.BeeHive, typeof(BeeHive));
				await EventPublisher.PublishAsync<Event<BeeHive>>(new Event<BeeHive>(command.BeeHive, EventAction.UPDATE));
			}
		}
	}
}
