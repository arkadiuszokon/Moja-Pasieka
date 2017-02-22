using System;
using System.Threading.Tasks;
using SQLite;
using MojaPasieka.DataModel;

namespace MojaPasieka.cqrs
{
	public class SaveParameterHandler : ICommandHandlerAsync<SaveParameter>
	{
		private SQLiteConnection _database;

		private IEventPublisher _eventBus;

		public SaveParameterHandler(SQLiteConnection database, IEventPublisher eventBus)
		{
			_database = database;
			_eventBus = eventBus;
		}

		public async Task HandleAsync(SaveParameter command)
		{
			Parameter.cache[command.pa_name] = command.pa_value;
			 _database.Execute("DELETE FROM tb_parameter WHERE pa_name = '" + command.pa_name + "'");
			 _database.Insert(new Parameter { pa_name = command.pa_name, pa_value = command.pa_value });
			await _eventBus.PublishAsync<ParameterWasChanged>(new ParameterWasChanged(command.pa_name, command.pa_value));
		}
	}
}
