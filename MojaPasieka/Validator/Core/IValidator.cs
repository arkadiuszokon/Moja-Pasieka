using System;
namespace MojaPasieka.cqrs
{
	/// <summary>
	/// Weryfikator komendy
	/// </summary>
	public interface IVerifier<TCommand> where TCommand : ICommand
	{
		bool verity(TCommand command);
	}
}
