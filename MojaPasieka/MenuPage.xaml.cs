using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace MojaPasieka
{
	public partial class MenuPage : ContentPage
	{
		public MenuPage()
		{
			InitializeComponent();
			imageTop.Source = ImageSource.FromResource("MojaPasieka.Assets.MenuBees");
			listView.ItemsSource = new ObservableCollection<MenuItem> { 
			
				new MenuItem { Title="Start", Icon=ImageSource.FromResource("MojaPasieka.Assets.Home") }

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
