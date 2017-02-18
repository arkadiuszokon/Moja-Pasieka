using System;
namespace MojaPasieka.cqrs
{
	public class GetParameter : IQuery<string>
	{
		public string pa_name;

		public GetParameter(string pa_name)
		{
			this.pa_name = pa_name;
		}
	}
}
