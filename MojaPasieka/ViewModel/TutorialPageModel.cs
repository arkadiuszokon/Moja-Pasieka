using System;
namespace MojaPasieka
{
	public class TutorialPageModel : IViewModel
	{
		public TutorialPageModel(TutorialPage view)
		{
			view.Title = "Tutorial";
		}
	}
}
