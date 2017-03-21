using System;
using MojaPasieka.DataModel;
using Autofac;
using MojaPasieka.cqrs;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace MojaPasieka.View
{
	public class ApiariesListModel :ViewModelBase, IViewModel, IConsumerAsync<Event<Apiary>>
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
					ShowApiaryDetails(value);
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
			SetData();
			using (var scope = IoC.container.BeginLifetimeScope())
			{
				scope.Resolve<IEventPublisher>().RegisterAsyncConsumer<Event<Apiary>>(this);
			}
		}

		public void SetData()
		{
			using (var scope = IoC.container.BeginLifetimeScope())
			{
				var qb = scope.Resolve<IQueryBus>();
				Apiaries = new ObservableCollection<Apiary>(qb.Process<GetFullListOf, List<object>>(new GetFullListOf(typeof(Apiary))).Cast<Apiary>().ToList());
			}
		}

		private void ShowApiaryDetails(Apiary apiary)
		{
			using (var scope = IoC.container.BeginLifetimeScope())
			{
				scope.Resolve<ICommandBus>().SendCommandAsync<ShowView>(new ShowView(new ApiaryDetails(apiary), false));
			}
		}

		private void AddApiary()
		{
			using (var scope = IoC.container.BeginLifetimeScope())
			{
				scope.Resolve<ICommandBus>().SendCommandAsync<ShowView>(new ShowView(new ApiaryEditable(), false));
			}
		}

		public async Task HandleAsync(Event<Apiary> eventMessage)
		{
			SetData();
		}
	}
}
