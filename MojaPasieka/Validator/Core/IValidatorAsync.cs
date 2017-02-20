using System;
using System.Threading.Tasks;

namespace MojaPasieka.cqrs
{
	/// <summary>
	/// Interfejs dla werykifikatora komend
	/// </summary>
	public interface IValidatorAsync<TCommand> where TCommand : ICommand
	{
		Task<ValidationResult> validate(TCommand command); 
	}
}
