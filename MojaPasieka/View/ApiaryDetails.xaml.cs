using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MojaPasieka.View
{
	public partial class ApiaryDetails : ViewPage<ApiaryDetailsModel>
	{
		public ApiaryDetails(DataModel.Apiary apiary) : base(apiary)
		{
			InitializeComponent();
		}
	}
}
