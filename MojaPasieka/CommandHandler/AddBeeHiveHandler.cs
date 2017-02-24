using System;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using MojaPasieka.DataModel;
using System.Diagnostics;

namespace MojaPasieka.cqrs
{
	public class AddBeeHiveHandler : ICommandHandlerAsync<AddBeeHive>
	{
		private SQLiteConnection _conn;

		private IEventPublisher _eventBus;

		public AddBeeHiveHandler(SQLiteConnection conn, IEventPublisher eventBus)
		{
			this._conn = conn;
			_eventBus = eventBus;
		}

		public async Task HandleAsync(AddBeeHive command)
		{
			_conn.Insert(command.beeHive);
			await _eventBus.PublishAsync<Event<BeeHive>>(new Event<BeeHive>(command.beeHive, EventAction.CREATE));

		}
	}
}
