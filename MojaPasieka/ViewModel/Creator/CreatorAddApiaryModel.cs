using System;
using System.Windows.Input;
using Xamarin.Forms;
using Autofac;
using MojaPasieka.cqrs;
using MojaPasieka.Utils;
using System.Diagnostics;
using System.Threading.Tasks;
using MojaPasieka.DataModel;

namespace MojaPasieka.View
{
	public class CreatorAddApiaryModel : ViewModelBase, IViewModel, IConsumerAsync<Event<Apiary>>
	{
		public System.Windows.Input.ICommand showMap { get; protected set;}

		public Command nextStep { get; protected set; }

		private bool _isNextStepVisible = true;

		public bool IsNextStepVisible
		{

			get
			{
				return _isNextStepVisible;
			}
			set
			{
				_isNextStepVisible = value;
				OnPropertyChanged(nameof(IsNextStepVisible));
			}
		}
		private string _location = "";

		public string location
		{
			get
			{
				return _location;
			}
			set
			{
				_location = value;
				OnPropertyChanged(nameof(location));
			}
		}

		private string _apiaryName = "";

		public string apiaryName
		{
			get
			{
				return _apiaryName;
			}
			set
			{
				_apiaryName = value;
				OnPropertyChanged(nameof(apiaryName));
			}
		}

		private string _apiaryDesc = "";

		public string apiaryDesc
		{
			get
			{
				return _apiaryDesc;
			}
			set
			{
				_apiaryDesc = value;
				OnPropertyChanged(nameof(apiaryDesc));
			}
		}

		public CreatorAddApiaryModel(CreatorAddApiary view)
		{
			showMap = new Command( async (obj) => {

				using (var scope = IoC.container.BeginLifetimeScope())
				{
					IMap map = scope.Resolve<IMap>();
					await map.showMapForLocation(SelectApiaryLocation);
					var eb = scope.Resolve<IEventPublisher>();
					eb.RegisterAsyncConsumer<Event<Apiary>>(this);
				}

			});

			nextStep = new Command(showNextStep);

		}


		private async void showNextStep(object obj)
		{
			using (var scope = IoC.container.BeginLifetimeScope())
			{
				var cb = scope.Resolve<ICommandBus>();
				try
				{
					await cb.SendCommandAsync<AddApiary>(new AddApiary(new DataModel.Apiary { ap_latlng = location, ap_name = apiaryName, ap_desc = apiaryDesc, ap_timestamp = DateTime.Now }));
				}
				catch (ValidationException ve)
				{
					scope.Resolve<INotification>().showAlert("Błąd", String.Join("\n", ve.result.message));
					return;
				}
				catch (Exception)
				{
					scope.Resolve<INotification>().showAlert("Błąd", "Nie można dadać pasieki");
					return;
				}

				var creator = scope.Resolve<Creator>();
				creator.nextStep();
				IsNextStepVisible = false;
			}
		}

		void SelectApiaryLocation(string userLocation)
		{
			location = userLocation;
		}

		public async Task HandleAsync(Event<Apiary> eventMessage)
		{
			if (eventMessage.action == EventAction.CREATE)
			{
				using (var scope = IoC.container.BeginLifetimeScope())
				{
					scope.Resolve<INotification>().showToast("Dodano pasiekę");

				}
			}
		}
	}
}
