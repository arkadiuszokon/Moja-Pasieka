using System;
namespace MojaPasieka.cqrs
{
	public class ParameterWasChanged : IEvent
	{
		public string pa_name;

		public string pa_value;


		public ParameterWasChanged(string pa_name, string pa_value)
		{
			this.pa_name = pa_name;
			this.pa_value = pa_value;
		}
	}
}
