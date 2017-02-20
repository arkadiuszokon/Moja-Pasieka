using System;
namespace MojaPasieka.cqrs
{
	public class ValidationResult
	{
		/// <summary>
		/// Wynik walidacji
		/// </summary>
		/// <value><c>true</c> if result; otherwise, <c>false</c>.</value>
		public bool result { get; set; }

		/// <summary>
		/// Komunikat o walidacji
		/// </summary>
		/// <value>The message.</value>
		public string message { get; set;}
	}
}
