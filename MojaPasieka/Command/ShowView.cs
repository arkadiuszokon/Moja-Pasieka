using System;
using MojaPasieka;
using Xamarin.Forms;

namespace MojaPasieka.cqrs
{
	public class ShowView : ICommandAsync
	{
		public ContentPage view;

		public bool asRoot;

		public ShowView(ContentPage view, bool asRoot)
		{
			this.view = view;
			this.asRoot = asRoot;
		}
	}
}
