using System;
using System.Collections.Generic;
using SQLite;

namespace MojaPasieka.DataModel
{
	[Table("tb_parameter")]
	public class Parameter : DataModelBase, IDataModel
	{
		public Parameter()
		{
		}

		public static Dictionary<string, string> cache = new Dictionary<string, string>();

		private string _pa_name;

		/// <summary>
		/// nazwa parametru
		/// </summary>
		/// <value>The name of the pa.</value>
		[Indexed]
		public string pa_name
		{
			get
			{
				return _pa_name;
			}
			set
			{
				_pa_name = value;
				OnPropertyChanged(nameof(pa_name));
			}
		}

		private string _pa_value;

		/// <summary>
		/// wartość parametru
		/// </summary>
		/// <value>The pa value.</value>
		public string pa_value
		{
			get
			{
				return _pa_value;
			}
			set
			{
				_pa_value = value;
				OnPropertyChanged(nameof(pa_value));
			}
		}


	}

	/// <summary>
	/// Klasa z nazwami parametrów
	/// </summary>
	public static class ParameterName
	{
		public const string TEST = "test";

		public const string TUTORIAL_STATUS = "tutorialStatus";
	}
}
