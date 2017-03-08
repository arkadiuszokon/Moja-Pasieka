using System;
using Xamarin.Forms;

namespace MojaPasieka.cqrs
{
	public class ShowModalView : ICommandAsync
	{
		public Page View { get; protected set;}

		public ShowModalView(Page view)
		{
			this.View = view; 
		}
	}
}
