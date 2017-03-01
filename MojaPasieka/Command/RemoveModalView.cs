using System;
using Xamarin.Forms;

namespace MojaPasieka.cqrs
{
	public class RemoveModalView : ICommandAsync
	{
		public Page view { get; protected set; }

		public RemoveModalView(Page view)
		{
			this.view = view;
		}
	}
}
