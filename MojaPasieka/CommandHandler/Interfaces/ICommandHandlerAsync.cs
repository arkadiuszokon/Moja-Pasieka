using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MojaPasieka.cqrs
{
	public interface ICommandHandlerAsync<in TCommand> where TCommand : ICommand
	{
		Task<ICollection<IEvent>> HandleAsync(TCommand command);

	}
}
