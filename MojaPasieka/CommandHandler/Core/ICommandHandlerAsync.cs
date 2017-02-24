using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MojaPasieka.cqrs
{
	public interface ICommandHandlerAsync<in TCommand> where TCommand : ICommandAsync
	{
		Task HandleAsync(TCommand command);

	}
}
