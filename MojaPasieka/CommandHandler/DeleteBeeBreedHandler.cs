using System;
using System.Threading.Tasks;
using SQLite;
using MojaPasieka.DataModel;

namespace MojaPasieka.cqrs
{
	public class DeleteBeeBreedHandler : ICommandHandlerAsync<DeleteBeeBreed>
	{
		private SQLiteConnection _conn;

		private IEventPublisher _eventBus;

		public DeleteBeeBreedHandler(SQLiteConnection conn, IEventPublisher eventBus)
		{
			this._conn = conn;
			_eventBus = eventBus;
		}

		public async Task HandleAsync(DeleteBeeBreed command)
		{
			_conn.Delete(command.breed);
			await _eventBus.PublishAsync<Event<BeeBreed>>(new Event<BeeBreed>(command.breed, EventAction.DELETE));
		}
	}
}
