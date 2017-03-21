using System;
using System.Collections.Generic;
using MojaPasieka.DataModel;
using Xamarin.Forms;

namespace MojaPasieka.View
{
	public partial class ApiaryEditable : ViewPage<ApiaryEditableModel>
	{
		public ApiaryEditable(Apiary existing) : base(existing)
		{
			InitializeComponent();
		}

		public ApiaryEditable()
		{
			InitializeComponent();
		}

	}
}
