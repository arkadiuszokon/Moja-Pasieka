using System;
using Flipper.Controls;
using Xamarin.Forms;

namespace MojaPasieka
{
	public class MyView : CardContentView
	{
		public MyView()
		{
			Content = new Label { Text = "Hello ContentView" };
		}
	}
}

