using System;
using SQLite;
using MojaPasieka.DataModel;
using System.Threading.Tasks;

namespace MojaPasieka.cqrs
{
	public class DeleteApiaryHandler : ICommandHandlerAsync<DeleteApiary>
	{
		private SQLiteConnection _conn;

		private IEventPublisher _eventBus;

		public DeleteApiaryHandler(SQLiteConnection conn, IEventPublisher eventBus)
		{
			this._conn = conn;
			_eventBus = eventBus;
		}

		public async Task HandleAsync(DeleteApiary command)
		{
			_conn.Delete(command.apiary);
			await _eventBus.PublishAsync<Event<Apiary>>(new Event<Apiary>(command.apiary, EventAction.DELETE));
		}
	}
}
