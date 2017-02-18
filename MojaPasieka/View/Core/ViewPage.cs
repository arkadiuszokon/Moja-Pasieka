using System;
using Xamarin.Forms;
using MojaPasieka.cqrs;
using Autofac;

namespace MojaPasieka
{
	public class ViewPage<T> : ContentPage where T : IViewModel
	{
		readonly T _viewModel;
		public T ViewModel
		{
			get { return _viewModel; }
		}

		public ViewPage()
		{
			using (var scope = IoC.container.BeginLifetimeScope())
			{
				_viewModel = scope.Resolve<T>(new TypedParameter(this.GetType(), this));
			}
			BindingContext = _viewModel;
		}
	}
}
