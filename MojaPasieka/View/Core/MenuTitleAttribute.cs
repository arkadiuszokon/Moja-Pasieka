using System;
namespace MojaPasieka.View
{
	[AttributeUsage(AttributeTargets.Class)]
	public class MenuTitleAttribute : Attribute
	{
		public string Title { get; protected set; }

		public MenuTitleAttribute(string title)
		{
			this.Title = title;
		}
	}
}
