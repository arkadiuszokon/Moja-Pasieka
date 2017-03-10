using System;
namespace MojaPasieka.cqrs
{
	public class ValidationException : Exception
	{
		public ValidationResult Result { get; protected set; }

		public ValidationException(ValidationResult result)
		{
			this.Result = result;
		}
	}
}
