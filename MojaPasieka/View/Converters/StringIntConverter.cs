using System;
using System.Globalization;
using Xamarin.Forms;

namespace MojaPasieka.View
{
	/// <summary>
	/// Konwerter string do int wykorzystywany np dla entry z numeric keyboard
	/// </summary>
	public class StringIntConverter : IValueConverter
	{
		public StringIntConverter()
		{
		}

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
			{
				return 0;
			}
			return value.ToString();
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			string strValue = value.ToString();
			if (string.IsNullOrEmpty(strValue))
			{
				strValue = "0";
			}
			int intValue;
			if (int.TryParse(strValue, out intValue))
			{
				return intValue;
			}
			return 0;
		}
	}
}
