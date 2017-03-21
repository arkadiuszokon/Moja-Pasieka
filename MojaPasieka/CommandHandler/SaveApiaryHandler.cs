using System;
using System.Threading.Tasks;
using MojaPasieka.DataModel;
using SQLite;
using Autofac;
using MojaPasieka.View;

namespace MojaPasieka.cqrs
{
	public class SaveApiaryHandler : CommandHandlerBase, ICommandHandlerAsync<SaveApiary>
	{
		public async Task HandleAsync(SaveApiary command)
		{
			if (command.Apiary.ap_id == 0)
			{
				Connection.Insert(command.Apiary, typeof(Apiary));
				await EventPublisher.PublishAsync<Event<Apiary>>(new Event<Apiary>(command.Apiary, EventAction.CREATE));
			}
			else
			{
				Connection.Update(command.Apiary, typeof(Apiary));
				await EventPublisher.PublishAsync<Event<Apiary>>(new Event<Apiary>(command.Apiary, EventAction.UPDATE));
			}
		}
	}
}
