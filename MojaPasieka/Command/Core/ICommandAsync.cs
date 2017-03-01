using System;
using MojaPasieka.cqrs;

namespace MojaPasieka.cqrs
{
	/// <summary>
	/// marker dla komend wykonywanych asynhronicznie
	/// </summary>
	public interface ICommandAsync : ICommand
	{
	}
}
