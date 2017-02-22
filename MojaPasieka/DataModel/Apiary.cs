using System;
using SQLite;
namespace MojaPasieka.DataModel
{
	/// <summary>
	/// Pasieka
	/// </summary>
	[Table("tb_apiary")]
	public class Apiary : DataModelBase, IDataModel
	{

		private int _ap_id;
		private string _ap_name;
		private string _ap_desc;
		private string _ap_latlng;
		private DateTime _ap_datecreated;
		private DateTime _ap_timestamp;

		/// <summary>
		/// Id pasieki
		/// </summary>
		/// <value>The ap identifier.</value>
		[PrimaryKey, AutoIncrement]
		public int ap_id
		{
			get
			{
				return _ap_id;
			}

			set
			{
				_ap_id = value;
				OnPropertyChanged(nameof(ap_id));
			}
		}

		/// <summary>
		/// Nazwa pasieki
		/// </summary>
		/// <value>The name of the ap.</value>
		public string ap_name
		{
			get
			{
				return _ap_name;
			}

			set
			{
				_ap_name = value;
				OnPropertyChanged(nameof(ap_name));
			}
		}

		/// <summary>
		/// Dodatkowy opis
		/// </summary>
		/// <value>The ap desc.</value>
		public string ap_desc
		{
			get
			{
				return _ap_desc;
			}

			set
			{
				_ap_desc = value;
				OnPropertyChanged(nameof(ap_desc));
			}
		}

		/// <summary>
		/// Współrzędne lokalizacji
		/// </summary>
		/// <value>The ap latlng.</value>
		public string ap_latlng
		{
			get
			{
				return _ap_latlng;
			}

			set
			{
				_ap_latlng = value;
				OnPropertyChanged(nameof(ap_latlng));
			}
		}

		/// <summary>
		/// Data utworzenia pasieki
		/// </summary>
		/// <value>The ap datecreated.</value>
		public DateTime ap_datecreated
		{
			get
			{
				return _ap_datecreated;
			}

			set
			{
				_ap_datecreated = value;
				OnPropertyChanged(nameof(ap_datecreated));
			}
		}


		public DateTime ap_timestamp
		{
			get
			{
				return _ap_timestamp;
			}

			set
			{
				_ap_timestamp = value;
				OnPropertyChanged(nameof(ap_timestamp));
			}
		}
	}
}
