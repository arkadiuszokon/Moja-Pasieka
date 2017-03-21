using System;
using System.Threading.Tasks;
using SQLite;
using MojaPasieka.DataModel;

namespace MojaPasieka.cqrs
{
	public class SaveBeeBreedHandler : CommandHandlerBase, ICommandHandlerAsync<SaveBeeBreed>
	{

		public async Task HandleAsync(SaveBeeBreed command)
		{
			if (command.Breed.bb_id == 0)
			{
				Connection.Insert(command.Breed, typeof(BeeBreed));
				await EventPublisher.PublishAsync<Event<BeeBreed>>(new Event<BeeBreed>(command.Breed, EventAction.CREATE));
			}
			else
			{
				Connection.Update(command.Breed, typeof(BeeBreed));
				await EventPublisher.PublishAsync<Event<BeeBreed>>(new Event<BeeBreed>(command.Breed, EventAction.UPDATE));
			}
		}
	}
}
