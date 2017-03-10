using System;
using System.Threading.Tasks;
using MojaPasieka.DataModel;
using SQLite;
using Autofac;
using MojaPasieka.View;

namespace MojaPasieka.cqrs
{
	public class AppApiaryHandler : CommandHandlerBase, ICommandHandlerAsync<AddApiary>
	{
		public async Task HandleAsync(AddApiary command)
		{
			Connection.Insert(command.Apiary);
			await EventPublisher.PublishAsync<Event<Apiary>>(new Event<Apiary>(command.Apiary, EventAction.CREATE));
		}
	}
}
