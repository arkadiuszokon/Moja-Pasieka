using System;
using System.Globalization;
using Xamarin.Forms;

namespace MojaPasieka.View
{
	/// <summary>
	/// Kowerter dla negacji boola
	/// </summary>
	public class BoolInvertConverter : IValueConverter
	{

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			bool booleanValue = (bool)value;
			return !booleanValue;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			bool booleanValue = (bool)value;
			return !booleanValue;
		}
	}
}
