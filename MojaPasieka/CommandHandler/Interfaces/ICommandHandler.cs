using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MojaPasieka.cqrs
{
	public interface ICommandHandler<in TCommand> where TCommand : ICommand
	{
		ICollection<IEvent> Handle(TCommand command);
	}
}
