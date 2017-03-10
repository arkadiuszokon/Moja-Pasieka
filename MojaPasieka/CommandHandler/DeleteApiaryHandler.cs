using System;
using SQLite;
using MojaPasieka.DataModel;
using System.Threading.Tasks;

namespace MojaPasieka.cqrs
{
	public class DeleteApiaryHandler : CommandHandlerBase, ICommandHandlerAsync<DeleteApiary>
	{

		public async Task HandleAsync(DeleteApiary command)
		{
			Connection.Delete(command.Apiary);
			await EventPublisher.PublishAsync<Event<Apiary>>(new Event<Apiary>(command.Apiary, EventAction.DELETE));
		}
	}
}
