using System;
using Xamarin.Forms;

namespace MojaPasieka
{
	public class HomePage : ViewPage<HomePageModel>
	{
		public HomePage()
		{
			Title = "Moja Pasieka";
			BackgroundColor = AppColors.BackGroundColor;
			Content = new StackLayout
			{
				Padding = new Thickness(20),
				Children = {
					new CardView { 
						

						Content =	new Label{Text="Moja pasieka app"}


					}
				}
			};
		}
	}
}