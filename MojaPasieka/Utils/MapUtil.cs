using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Autofac;
using MojaPasieka.cqrs;
using Xamarin.Forms.Maps;
using System.Collections.Generic;
using System.Diagnostics;
using TK.CustomMap;

namespace MojaPasieka.Utils
{
	public class MapUtil : IMap
	{
		public MapUtil()
		{
		}

		private static ContentPage cp;
		private static TK.CustomMap.TKCustomMapPin pin;
		private static Button btnOK;
		private static TKCustomMap map;

		private static Plugin.Geolocator.Abstractions.Position userLocation;

		public void showMap()
		{
			
		}

		public async Task showMapForLocation(Action<string> onUserSelectPoint, double currentLat = 0, double currentLng = 0)
		{

			if (cp == null)
			{
				cp = new ContentPage();
				cp.Title = "Podaj lokalizację";
				var sl = new StackLayout();
				btnOK = new Button();
				btnOK.Text = "Wybierz lokalizację";
				btnOK.HorizontalOptions = LayoutOptions.FillAndExpand;
				btnOK.HeightRequest = 80;
				btnOK.VerticalOptions = LayoutOptions.End;
				object style;
				App.Current.Resources.TryGetValue("buttonStyle", out style);
				btnOK.Style = style as Style;


				map = new TK.CustomMap.TKCustomMap(MapSpan.FromCenterAndRadius(new Position(52, 20), Distance.FromKilometers(100)));
				map.HorizontalOptions = LayoutOptions.FillAndExpand;
				map.VerticalOptions = LayoutOptions.FillAndExpand;
				map.IsShowingUser = false;
				sl.Children.Add(map);
				sl.Children.Add(btnOK);
				cp.Content = sl;


				map.MoveToRegion(MapSpan.FromCenterAndRadius(map.MapCenter, Distance.FromKilometers(3)));
				pin = new TK.CustomMap.TKCustomMapPin { Position = map.MapCenter, IsDraggable = true, ShowCallout = true, Title = "Lokalizacja pasieki" };
				map.CustomPins = new List<TK.CustomMap.TKCustomMapPin> { pin };
				map.MapClicked += (object sender, TK.CustomMap.TKGenericEventArgs<Position> e) =>
				{

					pin.Position = e.Value;

				};
				map.MapClickedCommand = new Command((obj) =>
				{

					Debug.WriteLine(obj);

				});
			}

			using (var scope = IoC.container.BeginLifetimeScope())
			{
				var cb = scope.Resolve<ICommandBus>();
				await cb.SendCommandAsync<ShowModalView>(new ShowModalView(cp));
			}
			if (currentLng != 0 && currentLat != 0)
			{
				var userPosition = new Position(currentLat, currentLng);
				map.MoveToRegion(MapSpan.FromCenterAndRadius(userPosition, Distance.FromKilometers(3)));
				pin.Position = userPosition;
			}
			else if (userLocation == null)
			{
				if(Device.RuntimePlatform == Device.Android)
				{
					if (Plugin.Geolocator.CrossGeolocator.Current.IsGeolocationAvailable && Plugin.Geolocator.CrossGeolocator.Current.IsGeolocationEnabled)
					{
						btnOK.Text = "Czekam na lokalizację...";
						userLocation = await Plugin.Geolocator.CrossGeolocator.Current.GetPositionAsync (10000);
						var userPosition = new Position (userLocation.Latitude, userLocation.Longitude);
						map.MoveToRegion(MapSpan.FromCenterAndRadius(userPosition, Distance.FromKilometers(3)));
						pin.Position = userPosition;
					}
				}
			}

			btnOK.Text = "Wybierz lokalizację";
			btnOK.Command = new Command( async (obj) => {
				
				onUserSelectPoint(pin.Position.Latitude.ToString() + ";" + pin.Position.Longitude.ToString());
				using (var scope = IoC.container.BeginLifetimeScope())
				{
					var cb = scope.Resolve<ICommandBus>();
					await cb.SendCommandAsync<RemoveModalView>(new RemoveModalView(cp));
				}
			});

		}


	}
}
