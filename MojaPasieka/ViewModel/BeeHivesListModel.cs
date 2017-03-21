using System;
using MojaPasieka.DataModel;
using Autofac;
using MojaPasieka.cqrs;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace MojaPasieka.View
{
	public class BeeHivesListModel : ViewModelBase, IViewModel, IConsumerAsync<ParameterWasChanged>
	{
		private static bool toRefresh = false;

		private BeeHivesList view;
		private ObservableCollection<BeeHivesListItem> _beeHives;
		private BeeHivesListItem _selectedBeeHive;

		public BeeHivesListItem SelectedBeeHive
		{
			get
			{
				return _selectedBeeHive;
			}
			set
			{
				if (value != null)
				{
					ShowBeeHiveDetails(value);
				}
				_selectedBeeHive = value;
				OnPropertyChanged(nameof(SelectedBeeHive));
			}
		}

		public ObservableCollection<BeeHivesListItem> BeeHives
		{
			get
			{
				return _beeHives;
			}
			set
			{
				_beeHives = value;
				OnPropertyChanged(nameof(BeeHives));
			}
		}

		public BeeHivesListModel(BeeHivesList view)
		{
			this.view = view;
			view.Appearing += View_Appearing;

			view.ToolbarItems.Add(new ToolbarItem
			{
				Text = "Dodaj nowy ul",
				Command = new Command(AddNewBeeHive),
				Order=ToolbarItemOrder.Secondary
			});
			view.ToolbarItems.Add(new ToolbarItem
			{
				Text = "Zbiorcze akcje",
				Command = new Command(MakeBulkAction),
				Order = ToolbarItemOrder.Secondary
			});

			using (var scope = IoC.container.BeginLifetimeScope())
			{
				scope.Resolve<IEventPublisher>().RegisterAsyncConsumer<ParameterWasChanged>(this);
			}
			SetData();
		}

		private void ShowBeeHiveDetails(BeeHive beeHive)
		{
			using (var scope = IoC.container.BeginLifetimeScope())
			{
				scope.Resolve<ICommandBus>().SendCommandAsync<ShowView>(new ShowView(new BeeHiveDetails(beeHive), false));
			}
		}

		protected void AddNewBeeHive()
		{
			
		}

		protected void MakeBulkAction()
		{
			//Todo uzupełnic
		}

		private void SetData()
		{
			using (var scope = IoC.container.BeginLifetimeScope())
			{
				try
				{
					var qb = scope.Resolve<IQueryBus>();
					var context = qb.Process<GetApiaryContext, Apiary>(new GetApiaryContext());
					view.Title = "Ule w pasiece ''" + context.ap_name + "''";
					BeeHives = new ObservableCollection<BeeHivesListItem>(qb.Process<GetBeeHivesList, List<BeeHivesListItem>>(new GetBeeHivesList(context.ap_id)));
				}
				catch (Exception ex)
				{
					ErrorUtil.handleError(ex);
				}
			}
		}

		void View_Appearing(object sender, EventArgs e)
		{
			if (toRefresh)
			{
				SetData();
				toRefresh = false;
			}
		}

		public async Task HandleAsync(ParameterWasChanged eventMessage)
		{
			if (eventMessage.pa_name == ParameterName.CURRENT_APIARY_ID)
			{
				toRefresh = true;
			}
		}
	}
}
