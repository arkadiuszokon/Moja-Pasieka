using System;
using MojaPasieka;
using Xamarin.Forms;

namespace MojaPasieka.cqrs
{
	public class ShowView : ICommandAsync
	{
		public ContentPage View { get; protected set; }

		public bool AsRoot { get; protected set; }

		public ShowView(ContentPage view, bool asRoot)
		{
			this.View = view;
			this.AsRoot = asRoot;
		}
	}
}
