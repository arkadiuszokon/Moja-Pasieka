using System;
using System.Collections.Generic;

namespace MojaPasieka.cqrs
{
	public class ValidationResult
	{
		/// <summary>
		/// Wynik walidacji
		/// </summary>
		/// <value><c>true</c> if result; otherwise, <c>false</c>.</value>
		public bool result = true;

		/// <summary>
		/// Komunikat o walidacji
		/// </summary>
		/// <value>The message.</value>
		public List<string> message  = new List<string>();
	}
}
