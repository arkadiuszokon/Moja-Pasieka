using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;
using Autofac;
using MojaPasieka.cqrs;
using Autofac.Core;
using System.Reflection;
using System.Linq;

namespace MojaPasieka.View
{
	public partial class MenuPage : ContentPage
	{
		public MenuPage()
		{
			InitializeComponent();
			imageTop.Source = ImageSource.FromResource("MojaPasieka.Assets.MenuBees");
			var menuItems = new ObservableCollection<MenuItem>();
			using (var scope = IoC.container.BeginLifetimeScope())
			{
				var items = scope.ComponentRegistry.RegistrationsFor(new TypedService(typeof(IMenuPage)));
				foreach (var menuItem in items)
				{
					var titleAttr = menuItem.Activator.LimitType.GetTypeInfo().GetCustomAttribute<MenuTitleAttribute>();
					menuItems.Add(new MenuItem
					{
						Title = titleAttr.Title,
						ViewItem = menuItem.Activator.LimitType
					});
				}
				menuList.ItemsSource = menuItems;
			}

			menuList.ItemSelected += (object sender, SelectedItemChangedEventArgs e) => 
			{
				try
				{
					using (var scope = IoC.container.BeginLifetimeScope())
					{
						var cb = scope.Resolve<ICommandBus>();
						cb.SendCommandAsync<ShowView>(new ShowView((scope.Resolve((e.SelectedItem as MenuItem).ViewItem) as ContentPage), true));
						App.Current.MainPage.SendBackButtonPressed();
					}
				}
				catch (Exception ex)
				{
					IoC.container.BeginLifetimeScope().Resolve<INotification>().showAlert("Błąd", ex.Message);
				}
			};
		}
	}

	public class MenuItem : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this,
			  new PropertyChangedEventArgs(propertyName));
		}

		private Type _viewItem;

		public Type ViewItem
		{
			get
			{
				return _viewItem;
			}
			set
			{
				_viewItem = value;
				OnPropertyChanged(nameof(ViewItem));
			}
		}

		private string _title;

		public string Title
		{
			get
			{
				return _title;
			}
			set
			{
				_title = value;
				OnPropertyChanged(nameof(Title));
			}
		}

		private ImageSource _icon;

		public ImageSource Icon
		{
			get
			{
				return _icon;
			}
			set
			{
				_icon = value;
				OnPropertyChanged(nameof(Icon));
			}
		}
	

	}
}
