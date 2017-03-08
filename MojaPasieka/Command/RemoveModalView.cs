using System;
using Xamarin.Forms;

namespace MojaPasieka.cqrs
{
	public class RemoveModalView : ICommandAsync
	{
		public Page View { get; protected set; }

		public RemoveModalView(Page view)
		{
			this.View = view;
		}
	}
}
