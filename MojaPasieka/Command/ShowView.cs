using System;
using MojaPasieka;
using Xamarin.Forms;

namespace MojaPasieka.cqrs
{
	public class ShowView : ICommandAsync
	{
		public ContentPage view { get; protected set; }

		public bool asRoot { get; protected set; }

		public ShowView(ContentPage view, bool asRoot)
		{
			this.view = view;
			this.asRoot = asRoot;
		}
	}
}
