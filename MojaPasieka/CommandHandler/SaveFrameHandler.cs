using System;
using System.Threading.Tasks;
using MojaPasieka.DataModel;
using SQLite;

namespace MojaPasieka.cqrs
{
	public class SaveFrameHandler :CommandHandlerBase, ICommandHandlerAsync<SaveFrame>
	{

		public async Task HandleAsync(SaveFrame command)
		{
			if (command.Frame.fr_id == 0)
			{
				Connection.Insert(command.Frame, typeof(Frame));
				await EventPublisher.PublishAsync<Event<Frame>>(new Event<Frame>(command.Frame, EventAction.CREATE));
			}
			else
			{
				Connection.Update(command.Frame, typeof(Frame));
				await EventPublisher.PublishAsync<Event<Frame>>(new Event<Frame>(command.Frame, EventAction.UPDATE));
			}
		}
	}
}
