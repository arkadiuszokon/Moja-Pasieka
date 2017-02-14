using System;
using Autofac;
namespace MojaPasieka
{

	public static class IoC
	{
		private static IContainer _container;

		public static IContainer container
		{
			get
			{
				return _container;
			}
			set
			{
				_container = value;
			}
		}
	}
}
