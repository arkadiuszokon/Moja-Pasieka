using System;
using MojaPasieka.cqrs;

namespace MojaPasieka
{
	/// <summary>
	/// marker dla komend wykonywanych asynhronicznie
	/// </summary>
	public interface ICommandAsync : ICommand
	{
	}
}
