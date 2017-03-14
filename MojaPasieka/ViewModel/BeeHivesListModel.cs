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
		private ObservableCollection<BeeHive> _beeHives;

		public ObservableCollection<BeeHive> BeeHives
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
			using (var scope = IoC.container.BeginLifetimeScope())
			{
				scope.Resolve<IEventPublisher>().RegisterAsyncConsumer<ParameterWasChanged>(this);
			}
			SetData();
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
					BeeHives = new ObservableCollection<BeeHive>(qb.Process<GetBeeHivesOnApiary, List<BeeHive>>(new GetBeeHivesOnApiary(context.ap_id)));
				}
				catch (Exception ex)
				{
					scope.Resolve<INotification>().showAlert("Błąd", ex.Message);
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
