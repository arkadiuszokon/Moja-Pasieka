﻿using System;
namespace MojaPasieka.View
{
	public class HomePageModel : IViewModel
	{
		public HomePageModel(HomePage view)
		{
			view.Title = "Strona główna";
		}
	}
}
