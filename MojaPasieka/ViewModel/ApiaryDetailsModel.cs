using System;
using System.Diagnostics;
using Xciles.PclValueInjecter;

namespace MojaPasieka.View
{
	public class ApiaryDetailsModel : MojaPasieka.DataModel.Apiary, IViewModel
	{
		public ApiaryDetailsModel(ApiaryDetails view, DataModel.Apiary context)
		{
			this.InjectFrom(context);
			Debug.WriteLine(this.ap_name);
		}

		/*public ApiaryDetailsModel()
		{
			Debug.WriteLine(this.ap_name);
		}*/
	}
}
