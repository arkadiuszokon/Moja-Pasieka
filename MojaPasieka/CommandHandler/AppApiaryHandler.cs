using System;
using System.Threading.Tasks;
using MojaPasieka.DataModel;
using SQLite;
namespace MojaPasieka.cqrs
{
	public class AppApiaryHandler : ICommandHandlerAsync<AddApiary>
	{
		private SQLiteConnection _conn;

		private IEventPublisher _eventBus;

		public AppApiaryHandler(SQLiteConnection conn, IEventPublisher eventBus)
		{
			this._conn = conn;
			_eventBus = eventBus;
		}

		public async Task HandleAsync(AddApiary command)
		{
			_conn.Insert(command.apiary);
			await _eventBus.PublishAsync<Event<Apiary>>(new Event<Apiary>(command.apiary, EventAction.CREATE));
		}
	}
}
