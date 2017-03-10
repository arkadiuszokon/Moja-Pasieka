using System;
using System.Threading.Tasks;
using SQLite;
using MojaPasieka.DataModel;

namespace MojaPasieka.cqrs
{
	public class AddBeeBreedHandler : CommandHandlerBase, ICommandHandlerAsync<AddBeeBreed>
	{

		public async Task HandleAsync(AddBeeBreed command)
		{
			Connection.Insert(command.Breed);
			await EventPublisher.PublishAsync<Event<BeeBreed>>(new Event<BeeBreed>(command.Breed, EventAction.CREATE));
		}
	}
}
