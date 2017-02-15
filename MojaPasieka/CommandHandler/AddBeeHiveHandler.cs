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

		public AddBeeHiveHandler(SQLiteAsyncConnection conn)
		{
			this._conn = conn;
		}

		public async Task<ICollection<IEvent>> HandleAsync(AddBeeHiveCommand command)
		{
			try
			{
				var beeHiveID = await _conn.InsertAsync(command.beeHive);
				command.beeHive.ul_id = beeHiveID;
				return new List<IEvent> { new BeeHiveAddedEvent(command.beeHive) };
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.ToString());
			}
			return new List<IEvent>() { };
		}
	}
}
