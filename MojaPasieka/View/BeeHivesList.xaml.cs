using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MojaPasieka.View
{
	[MenuTitle("Ule")]
	public partial class BeeHivesList : ViewPage<BeeHivesListModel>, IMenuPage
	{
		public BeeHivesList()
		{
			InitializeComponent();
			beeHivesList.ItemSelected += (sender, e) =>
			{
				((ListView)sender).SelectedItem = null;
			};
		}
	}
}
