using System;
using SQLite.Net.Async;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MojaPasieka.cqrs
{
	public class AddBeeHiveHandler : ICommandHandlerAsync<AddBeeHiveCommand>
	{
		private SQLiteAsyncConnection _conn;

		public AddBeeHiveHandler(SQLiteAsyncConnection conn)
		{
			this._conn = conn;
		}

		public async Task<ICollection<IEvent>> HandleAsync(AddBeeHiveCommand command)
		{
			
			var beeHiveID = await _conn.InsertAsync(command.beeHive);
			command.beeHive.ul_id = beeHiveID;
			return new List<IEvent> { new BeeHiveAddedEvent(command.beeHive) };

		}
	}
}
