using System;
using System.Threading.Tasks;

namespace MojaPasieka.cqrs
{
	/// <summary>
	/// Interfejs dla werykifikatora komend
	/// </summary>
	public interface IValidatorAsync<TCommand> where TCommand : ICommandAsync
	{
		Task<ValidationResult> ValidateAsync(TCommand command); 
	}
}
