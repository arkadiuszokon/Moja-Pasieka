using System;
namespace MojaPasieka.View
{
	public class TutorialPageModel : IViewModel
	{
		public TutorialPageModel(TutorialPage view)
		{
			view.Title = "Tutorial";
		}
	}
}
