using System;
using System.ComponentModel;

namespace MojaPasieka.DataModel
{
	public class DataModelBase: INotifyPropertyChanged
	{

		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged(string propertyName)
		{
			
				this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

		}

		public virtual Type GetDataModelType()
		{
			
				return this.GetType();


		}

	}
}
