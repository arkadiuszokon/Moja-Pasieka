using System;
using System.ComponentModel;

namespace MojaPasieka
{
	public abstract class ViewModelBase : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged(string propertyName)
		{

			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

		}
	}
}
