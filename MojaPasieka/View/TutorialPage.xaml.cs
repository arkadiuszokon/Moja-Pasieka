using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MojaPasieka.View
{
	[MenuTitle("Tutorial")]
	public partial class TutorialPage : ViewPage<TutorialPageModel>, IMenuPage
	{
		public TutorialPage()
		{
			InitializeComponent();
		}
	}
}
