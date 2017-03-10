using System;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using MojaPasieka.DataModel;
using System.Diagnostics;

namespace MojaPasieka.cqrs
{
	public class AddBeeHiveHandler : CommandHandlerBase, ICommandHandlerAsync<AddBeeHive>
	{
		public async Task HandleAsync(AddBeeHive command)
		{
			Connection.Insert(command.BeeHive);
			await EventPublisher.PublishAsync<Event<BeeHive>>(new Event<BeeHive>(command.BeeHive, EventAction.CREATE));
		}
	}
}
