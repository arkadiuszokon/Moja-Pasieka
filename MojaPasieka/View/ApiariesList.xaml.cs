using System;
using System.Collections.Generic;
using MojaPasieka.DataModel;
using Xamarin.Forms;

namespace MojaPasieka.View
{
	[MenuTitle("Pasieki")]
	public partial class ApiariesList : ViewPage<ApiariesListModel>, IMenuPage
	{
		public ApiariesList()
		{
			InitializeComponent();
			apiariesList.ItemSelected += (sender, e) =>
			{
				((ListView)sender).SelectedItem = null;
			};
		}
	}
}
