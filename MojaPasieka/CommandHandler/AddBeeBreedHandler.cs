using System;
using System.Threading.Tasks;
using SQLite;
using MojaPasieka.DataModel;

namespace MojaPasieka.cqrs
{
	public class AddBeeBreedHandler : ICommandHandlerAsync<AddBeeBreed>
	{
		private SQLiteConnection _conn;

		private IEventPublisher _eventBus;

		public AddBeeBreedHandler(SQLiteConnection conn, IEventPublisher eventBus)
		{
			this._conn = conn;
			_eventBus = eventBus;
		}

		public async Task HandleAsync(AddBeeBreed command)
		{
			_conn.Insert(command.Breed);
			await _eventBus.PublishAsync<Event<BeeBreed>>(new Event<BeeBreed>(command.Breed, EventAction.CREATE));
		}
	}
}
