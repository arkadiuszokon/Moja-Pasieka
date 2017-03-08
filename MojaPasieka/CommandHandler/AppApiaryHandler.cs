using System;
using System.Threading.Tasks;
using MojaPasieka.DataModel;
using SQLite;
using Autofac;
using MojaPasieka.View;

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
			_conn.Insert(command.Apiary);
			await _eventBus.PublishAsync<Event<Apiary>>(new Event<Apiary>(command.Apiary, EventAction.CREATE));
		}
	}
}
