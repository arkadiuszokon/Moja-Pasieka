using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace MojaPasieka.View
{
	public class TutorialPageModel : ViewModelBase, IViewModel
	{
		public TutorialPageModel(TutorialPage view)
		{
			view.Title = "Tutorial";
			showCreator = new Command((obj) => {

				App.Current.MainPage = new Creator();

			});
		}

		public ICommand showCreator { get; protected set; }

	}
}
