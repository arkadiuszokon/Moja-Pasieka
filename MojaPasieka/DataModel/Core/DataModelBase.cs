using System;
using System.ComponentModel;

namespace MojaPasieka.DataModel
{
	public class DataModelBase: INotifyPropertyChanged
	{
		protected object lockObject = new object();

		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged(string propertyName)
		{
			lock(lockObject)
			{
				this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		public virtual Type getDataModelType()
		{
			lock(lockObject)
			{
				return this.GetType();
			}

		}

	}
}
