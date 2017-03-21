using System;
using Xamarin.Forms;

namespace MojaPasieka.View
{
	public class AppMainPage : MasterDetailPage
	{

		public static NavigationPage nav { get; private set; }

		private static AppMainPage _instance;

		/// <summary>
		/// Usnawia stronę jako root w elemencie Detail
		/// </summary>
		/// <param name="page">Page.</param>
		public static void setRootPage(ContentPage page)
		{
			nav = new NavigationPage(page);
			nav.BarBackgroundColor = AppColors.MainColor;
			nav.BarTextColor = AppColors.TextColor;
			_instance.Detail = nav;
		}

		public AppMainPage()
		{
			Master = new MenuPage();
			nav = new NavigationPage(new HomePage {});
			nav.BarBackgroundColor = AppColors.MainColor;
			nav.BarTextColor = AppColors.TextColor;
			Detail = nav;
			_instance = this;
		}
	}
}

