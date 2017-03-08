using System;
using System.Threading.Tasks;
using MojaPasieka.DataModel;
using SQLite;

namespace MojaPasieka.cqrs
{
	public class AddFrameHandler : ICommandHandlerAsync<AddFrame>
	{
		private SQLiteConnection _conn;

		private IEventPublisher _eventBus;

		public AddFrameHandler(SQLiteConnection conn, IEventPublisher eventBus)
		{
			this._conn = conn;
			_eventBus = eventBus;
		}

		public async Task HandleAsync(AddFrame command)
		{
			_conn.Insert(command.Frame);
			await _eventBus.PublishAsync<Event<Frame>>(new Event<Frame>(command.Frame, EventAction.CREATE));
		}
	}
}
