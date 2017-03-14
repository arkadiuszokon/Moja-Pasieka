using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xciles.PclValueInjecter;
using Autofac;
using MojaPasieka.cqrs;
using MojaPasieka.DataModel;
using TK.CustomMap;
using Xamarin.Forms.Maps;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MojaPasieka.View
{
	public class ApiaryDetailsModel : MojaPasieka.DataModel.Apiary, IViewModel
	{
		private Position _location;
		private ObservableCollection<TKCustomMapPin> _pins;
		private string _beeHivesCount;

		public string BeeHivesCount
		{
			get
			{
				return _beeHivesCount;
			}
			set
			{
				_beeHivesCount = value;
				OnPropertyChanged(nameof(BeeHivesCount));
			}
		}

		public ObservableCollection<TKCustomMapPin> Pins
		{
			get
			{
				return _pins;
			}
			set
			{
				_pins = value;
				OnPropertyChanged(nameof(Pins));
			}
		}

		public Position Location
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

		public ApiaryDetailsModel(ApiaryDetails view, DataModel.Apiary context)
		{
			this.InjectFrom(context);
			view.Title = "Pasieka ''" + ap_name + "''"; 
			Debug.WriteLine(this.ap_name);

			using (var scope = IoC.container.BeginLifetimeScope())
			{
				var qb = scope.Resolve<IQueryBus>();
				var currentApiaryID = qb.Process<GetParameter, string>(new GetParameter(ParameterName.CURRENT_APIARY_ID));
				if (currentApiaryID != ap_id.ToString())
				{
					view.ToolbarItems.Add(new ToolbarItem
					{
						Text = "Pracuj na tej pasiece",
						Command = new Command(ChooseApiary),
						Order = ToolbarItemOrder.Secondary
					});
				}
				var latlng = ap_latlng.Split(';');
				if (latlng.Length > 1)
				{
					var lat = Double.Parse(latlng[0]);
					var lng = Double.Parse(latlng[1]);
					Location = new Position(lat, lng);
					Pins = new ObservableCollection<TKCustomMapPin>();
					Pins.Add(new TKCustomMapPin
					{
						Position = Location,
						IsDraggable = false,
						Title = "Lokalizacja pasieki"
					});
				}
				var beeHives = qb.Process<GetBeeHivesOnApiary, List<BeeHive>>(new GetBeeHivesOnApiary(ap_id));
				BeeHivesCount = beeHives.Count.ToString();
			}

			view.ToolbarItems.Add(new ToolbarItem
			{
				Text = "Edytuj pasiekę",
				Command = new Command(EditApiary),
				Order = ToolbarItemOrder.Secondary
			});
			view.ToolbarItems.Add(new ToolbarItem
			{
				Text = "Usuń pasiekę",
				Command = new Command(DeleteApiary),
				Order = ToolbarItemOrder.Secondary
			});
		}

		private void ChooseApiary()
		{
			using (var scope = IoC.container.BeginLifetimeScope())
			{
				scope.Resolve<ICommandBus>().SendCommandAsync<SaveParameter>(new SaveParameter(ParameterName.CURRENT_APIARY_ID, ap_id.ToString()));
				scope.Resolve<INotification>().showToast("Zmieniono konktekst pasieki");
			}
		}

		private void DeleteApiary()
		{

		}

		private void EditApiary()
		{

		}
	}
}
