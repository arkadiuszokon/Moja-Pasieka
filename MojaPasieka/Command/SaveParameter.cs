using System;
namespace MojaPasieka.cqrs
{
	/// <summary>
	/// komenda zapisu parametru
	/// </summary>
	public class SaveParameter : ICommandAsync
	{
		public string pa_name { get; protected set; }

		public string pa_value { get; protected set; }

		public SaveParameter(string pa_name, string pa_value)
		{
			this.pa_name = pa_name;
			this.pa_value = pa_value;
		}
	}
}
