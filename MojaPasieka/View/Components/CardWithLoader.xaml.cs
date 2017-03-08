using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MojaPasieka.View
{
	public partial class CardWithLoader : CardView
	{
		private string _message = "";

		public string Message 
		{ 
			get
			{
				return _message;
			}
			set
			{
				_message = value;
				message.Text = value;
			}
		}

		public CardWithLoader()
		{
			InitializeComponent();
			loader.Color = AppColors.MainColor;
		}
	}
}
