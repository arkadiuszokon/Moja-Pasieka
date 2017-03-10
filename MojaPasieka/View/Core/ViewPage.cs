using System;
using Xamarin.Forms;
using MojaPasieka.cqrs;
using Autofac;

namespace MojaPasieka.View
{
	public abstract  class ViewPage<T> : ContentPage where T : IViewModel
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

		public ViewPage(object viewModelContext)
		{
			using (var scope = IoC.container.BeginLifetimeScope())
			{
				_viewModel = scope.Resolve<T>(new TypedParameter(this.GetType(), this), new NamedParameter("context", viewModelContext));
			}
			BindingContext = _viewModel;
		}
	}
}
