using System;
using System.Threading.Tasks;
using MojaPasieka.DataModel;
using SQLite;

namespace MojaPasieka.cqrs
{
	public class AddFrameHandler :CommandHandlerBase, ICommandHandlerAsync<AddFrame>
	{

		public async Task HandleAsync(AddFrame command)
		{
			Connection.Insert(command.Frame);
			await EventPublisher.PublishAsync<Event<Frame>>(new Event<Frame>(command.Frame, EventAction.CREATE));
		}
	}
}
