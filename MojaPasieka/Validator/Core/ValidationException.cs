using System;
namespace MojaPasieka.cqrs
{
	public class ValidationException : Exception
	{
		public ValidationResult result { get; protected set; }

		public ValidationException(ValidationResult result)
		{
			this.result = result;
		}
	}
}
