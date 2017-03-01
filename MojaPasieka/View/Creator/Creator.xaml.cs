using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MojaPasieka.View
{
	public partial class Creator : CarouselPage
	{

		private static readonly ContentPage[] creatorPages = new ContentPage[] { 
		
			new CreatorStart(),
			new CreatorAddApiary()

		};

		public Creator()
		{
			InitializeComponent();
			this.Children.Add(creatorPages[0]);
		}

		public void nextStep()
		{
			for (int i = 0; i < creatorPages.Length; i++)
			{
				if (CurrentPage == creatorPages[i])
				{
					if (creatorPages.Length - 1 > i)
					{
						this.Children.Add(creatorPages[i + 1]);
						this.CurrentPage = creatorPages[i + 1];
						return;
					}
				}
			}
		}

	}
}
