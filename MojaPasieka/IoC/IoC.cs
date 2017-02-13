using System;
namespace MojaPasieka.IoC
{

	public static class IoC
	{
		private static SimpleContainer _container;

		public static SimpleContainer container
		{
			get
			{
				if (_container == null)
				{
					_container = new SimpleContainer();
				}
				return _container;
			}
		}
	}
}
