using System;
using System.Threading.Tasks;

namespace MojaPasieka.cqrs
{
	/// <summary>
	/// Interfejs dla werykifikatora komend
	/// </summary>
	public interface IVerifierAsync<TCommand> where TCommand : ICommand
	{
		Task<bool> verify(TCommand command);
	}
}
