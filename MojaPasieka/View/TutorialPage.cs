using System;

using Xamarin.Forms;

namespace MojaPasieka
{
	public class TutorialPage : ViewPage<TutorialPageModel>
	{
		public TutorialPage()
		{
			Content = new ScrollView {
				
				Content =  new Frame {

					Content = new Label { Text = "Witam w tutorialu"}

				}
			};
		}
	}
}

