using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using SQLite;

namespace MojaPasieka.DataModel
{
	public abstract class DataModelBase: INotifyPropertyChanged
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

		/// <summary>
		/// Pobranie wartości atrybutu
		/// </summary>
		/// <returns>The value.</returns>
		/// <param name="enumValue">Enum value.</param>
		/// <typeparam name="TEnum">The 1st type parameter.</typeparam>
		public static string GetTableName(Type dataModelClass)
		{
			
			var attr = dataModelClass.GetTypeInfo().GetCustomAttributes(typeof(TableAttribute)).FirstOrDefault();
			if (attr == null)
			{
				return "";
			}
			return (attr as TableAttribute).Name;
		}

	}
}
