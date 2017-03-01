using System;
using Xamarin.Forms;

namespace MojaPasieka.cqrs
{
	public class ShowModalView : ICommandAsync
	{
		public Page view { get; protected set;}

		public ShowModalView(Page view)
		{
			this.view = view; 
		}
	}
}
