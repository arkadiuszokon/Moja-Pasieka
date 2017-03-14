using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MojaPasieka.View
{
	[MenuTitle("Strona główna")]
	public partial class HomePage : ViewPage<HomePageModel>, IMenuPage
	{
		public HomePage()
		{
			InitializeComponent();
		}

	}
}
