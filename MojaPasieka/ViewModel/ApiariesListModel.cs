using System;
using MojaPasieka.DataModel;
using Autofac;
using MojaPasieka.cqrs;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MojaPasieka.View
{
	public class ApiariesListModel :ViewModelBase, IViewModel
	{

		private ObservableCollection<Apiary> _apiaries;
		private Apiary _selectedApiary;

		public Apiary SelectedApiary
		{
			get
			{
				return _selectedApiary;
			}
			set
			{
				if (value != null)
				{
					showApiaryDetails(value);
				}
				_selectedApiary = null;
				OnPropertyChanged(nameof(SelectedApiary));
			}
		}


		public ObservableCollection<Apiary> Apiaries
		{
			get
			{
				return _apiaries;
			}
			set
			{
				_apiaries = value;
				OnPropertyChanged(nameof(Apiaries));
			}
		}

		public ApiariesListModel(ApiariesList view)
		{
			view.Title = "Pasieki";
			view.ToolbarItems.Add(new ToolbarItem
			{
				Text = "Nowa pasieka",
				Command = new Command(AddApiary),
				Order = ToolbarItemOrder.Secondary
			});
			using (var scope = IoC.container.BeginLifetimeScope())
			{
				var qb = scope.Resolve<IQueryBus>();
				Apiaries = new ObservableCollection<Apiary>(qb.Process<GetFullListOf, List<object>>(new GetFullListOf(typeof(Apiary))).Cast<Apiary>().ToList());
			}

		}

		private void showApiaryDetails(Apiary apiary)
		{
			using (var scope = IoC.container.BeginLifetimeScope())
			{
				scope.Resolve<ICommandBus>().SendCommandAsync<ShowView>(new ShowView(new ApiaryDetails(apiary), false));
			}
		}

		private void AddApiary()
		{

		}
	}
}
