using System;
using System.Threading.Tasks;
using SQLite;
using MojaPasieka.DataModel;

namespace MojaPasieka.cqrs
{
	public class DeleteBeeBreedHandler :CommandHandlerBase, ICommandHandlerAsync<DeleteBeeBreed>
	{

		public async Task HandleAsync(DeleteBeeBreed command)
		{
			Connection.Delete(command.Breed);
			await EventPublisher.PublishAsync<Event<BeeBreed>>(new Event<BeeBreed>(command.Breed, EventAction.DELETE));
		}
	}
}
