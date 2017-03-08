using System;
using System.Threading.Tasks;
using MojaPasieka.DataModel;
using SQLite;

namespace MojaPasieka.cqrs
{
	public class AddBeeHibeBodyHandler : ICommandHandlerAsync<AddBeeHiveBody>
	{
		private SQLiteConnection _conn;

		private IEventPublisher _eventBus;

		public AddBeeHibeBodyHandler(SQLiteConnection conn, IEventPublisher eventBus)
		{
			this._conn = conn;
			_eventBus = eventBus;
		}

		public async Task HandleAsync(AddBeeHiveBody command)
		{
			_conn.Insert(command.Body);
			await _eventBus.PublishAsync<Event<BeeHiveBody>>(new Event<BeeHiveBody>(command.Body, EventAction.CREATE));
		}
	}
}
