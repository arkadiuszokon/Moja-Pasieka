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
		public Command ShowMap { get; protected set;}
		public Command NextStep { get; protected set; }
		public Command AddApiary { get; protected set; }
		private bool _isNextStepVisible = true;
		private bool _isAddApiaryVisible = true;
		private DateTime _dateCreated = DateTime.Now;
		private string _location = "";
		private string _apiaryName = "";
		private string _apiaryDesc = "";

		public DateTime DateCreated
		{
			get
			{
				return _dateCreated;
			}
			set
			{
				_dateCreated = value;
				OnPropertyChanged(nameof(DateCreated));
			}
		}

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


		public bool IsAddApiaryVisible
		{
			get
			{
				return _isAddApiaryVisible;
			}
			set
			{
				_isAddApiaryVisible = value;
				OnPropertyChanged(nameof(IsAddApiaryVisible));
				OnPropertyChanged(nameof(IsReadyVisible));
			}


		}

		public bool IsReadyVisible
		{
			get
			{
				return !_isAddApiaryVisible;
			}
		}

		public string Location
		{
			get
			{
				return _location;
			}
			set
			{
				_location = value;
				OnPropertyChanged(nameof(Location));
			}
		}

		public string ApiaryName
		{
			get
			{
				return _apiaryName;
			}
			set
			{
				_apiaryName = value;
				OnPropertyChanged(nameof(ApiaryName));
			}
		}

		public string ApiaryDesc
		{
			get
			{
				return _apiaryDesc;
			}
			set
			{
				_apiaryDesc = value;
				OnPropertyChanged(nameof(ApiaryDesc));
			}
		}

		public CreatorAddApiaryModel(CreatorAddApiary view)
		{
			ShowMap = new Command( async (obj) => 
			{

				using (var scope = IoC.container.BeginLifetimeScope())
				{
					IMap map = scope.Resolve<IMap>();
					await map.showMapForLocation(SelectApiaryLocation);
					var eb = scope.Resolve<IEventPublisher>();
					eb.RegisterAsyncConsumer<Event<Apiary>>(this);
				}

			});

			NextStep = new Command((obj) => 
			{ 
				using (var scope = IoC.container.BeginLifetimeScope())
				{
					var creator = scope.Resolve<Creator>();
					creator.nextStep();
					IsNextStepVisible = false;
				}
			});
			AddApiary = new Command(async (object obj) => 
			{
				using (var scope = IoC.container.BeginLifetimeScope())
				{
					var cb = scope.Resolve<ICommandBus>();
					try
					{
						await cb.SendCommandAsync<AddApiary>(new AddApiary(new DataModel.Apiary { ap_datecreated = DateCreated, ap_latlng = Location, ap_name = ApiaryName, ap_desc = ApiaryDesc, ap_timestamp = DateTime.Now }));
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

				}

			});
		}




		void SelectApiaryLocation(string userLocation)
		{
			Location = userLocation;
		}

		public async Task HandleAsync(Event<Apiary> eventMessage)
		{
			if (eventMessage.action == EventAction.CREATE)
			{
				using (var scope = IoC.container.BeginLifetimeScope())
				{
					scope.Resolve<INotification>().showToast("Dodano pasiekę");
					IsAddApiaryVisible = false;
					scope.Resolve<Creator>().setApiaryContext(eventMessage.item);
				}
			}
		}
	}
}
