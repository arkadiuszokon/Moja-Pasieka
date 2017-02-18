using System;
namespace MojaPasieka.cqrs
{
	/// <summary>
	/// komenda zapisu parametru
	/// </summary>
	public class SaveParameter : ICommand
	{
		public string pa_name;

		public string pa_value;

		public SaveParameter(string pa_name, string pa_value)
		{
			this.pa_name = pa_name;
			this.pa_value = pa_value;
		}
	}
}
