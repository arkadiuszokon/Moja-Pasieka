using System;
using System.Collections.Generic;
using MojaPasieka.DataModel;

using Xamarin.Forms;

namespace MojaPasieka.View
{
	public partial class BeeHiveDetails : ViewPage<BeeHiveDetailsModel>
	{
		public BeeHiveDetails(BeeHive context) : base(context)
		{
			InitializeComponent();
		}
	}
}
