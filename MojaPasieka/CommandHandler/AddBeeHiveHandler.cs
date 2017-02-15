using System;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MojaPasieka.cqrs
{
	public class AddBeeHiveHandler : ICommandHandlerAsync<AddBeeHive>
	{
		private SQLiteAsyncConnection _conn;

		private IEventPublisher _eventBus;

		public AddBeeHiveHandler(SQLiteAsyncConnection conn, IEventPublisher eventBus)
		{
			this._conn = conn;
			_eventBus = eventBus;
		}

		public async Task HandleAsync(AddBeeHive command)
		{
			try
			{
				await _conn.InsertAsync(command.beeHive);
				await _eventBus.PublishAsync<BeeHiveWasAdded>(new BeeHiveWasAdded(command.beeHive));

			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.ToString());
			}
		}
	}
}
