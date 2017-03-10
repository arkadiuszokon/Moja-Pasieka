using System;
using System.Threading.Tasks;
using SQLite;
using MojaPasieka.DataModel;

namespace MojaPasieka.cqrs
{
	public class SaveParameterHandler : CommandHandlerBase, ICommandHandlerAsync<SaveParameter>
	{

		public async Task HandleAsync(SaveParameter command)
		{
			Parameter.cache[command.pa_name] = command.pa_value;
			Connection.Execute("DELETE FROM tb_parameter WHERE pa_name = '" + command.pa_name + "'");
			Connection.Insert(new Parameter { pa_name = command.pa_name, pa_value = command.pa_value });
			await EventPublisher.PublishAsync<ParameterWasChanged>(new ParameterWasChanged(command.pa_name, command.pa_value));
		}
	}
}
