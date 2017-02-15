using System;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MojaPasieka.cqrs
{
	public class AddBeeHiveHandler : ICommandHandlerAsync<AddBeeHiveCommand>
	{
		private SQLiteAsyncConnection _conn;

		private IEventPublisher _eventBus;

		public AddBeeHiveHandler(SQLiteAsyncConnection conn, IEventPublisher eventBus)
		{
			this._conn = conn;
			_eventBus = eventBus;
		}

		public async Task HandleAsync(AddBeeHiveCommand command)
		{
			try
			{
				var beeHiveID = await _conn.InsertAsync(command.beeHive);
				command.beeHive.ul_id = beeHiveID;
				await _eventBus.PublishAsync<BeeHiveAddedEvent>(new BeeHiveAddedEvent(command.beeHive));

			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.ToString());
			}
		}
	}
}
