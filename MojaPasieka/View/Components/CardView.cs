using System;

using Xamarin.Forms;

namespace MojaPasieka.View
{
	public class CardView : Frame
	{

		public CardView()
		{
			if (Device.OS == TargetPlatform.iOS)
			{
				HasShadow = false;
				OutlineColor = Color.Transparent;
				BackgroundColor = Color.Transparent;
			}
			else if (Device.OS == TargetPlatform.Android)
			{
				HasShadow = true;
				OutlineColor = Color.Transparent;
				BackgroundColor = Color.White;
			}


		}
	}
}

