using System;
namespace MojaPasieka.cqrs
{
	/// <summary>
	/// Weryfikator komendy
	/// </summary>
	public interface IValidator<TCommand> where TCommand : ICommand 
	{
		ValidationResult validate(TCommand command);
	}
}
