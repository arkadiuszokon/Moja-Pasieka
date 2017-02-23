using System;
using SQLite;

namespace MojaPasieka.DataModel
{
	/// <summary>
	/// Zbiór pyłku
	/// </summary>
	[Table("tb_pollenharvest")]
	public class PollenHarvest : DataModelBase, IDataModel
	{

		private int _ph_id;
		private int _ph_pt_id;
		private int _ph_bc_id;
		private decimal _ph_quan;
		private string _ph_desc;
		private DateTime _ph_dateadd;
		private DateTime _ph_timestamp;

		/// <summary>
		/// Id zbioru pyłku
		/// </summary>
		/// <value>The ph identifier.</value>
		[PrimaryKey, AutoIncrement]
		public int ph_id
		{
			get
			{
				return _ph_id;
			}

			set
			{
				_ph_id = value;
				OnPropertyChanged(nameof(ph_id));
			}
		}

		/// <summary>
		/// Id poławiacza
		/// </summary>
		/// <value>The ph point identifier.</value>
		[Indexed]
		public int ph_pt_id
		{
			get
			{
				return _ph_pt_id;
			}

			set
			{
				_ph_pt_id = value;
				OnPropertyChanged(nameof(ph_pt_id));
			}
		}

		/// <summary>
		/// Id rodziny
		/// </summary>
		/// <value>The ph bc identifier.</value>
		[Indexed]
		public int ph_bc_id
		{
			get
			{
				return _ph_bc_id;
			}

			set
			{
				_ph_bc_id = value;
				OnPropertyChanged(nameof(ph_bc_id));
			}
		}

		/// <summary>
		/// Zebrana ilosc
		/// </summary>
		/// <value>The ph quan.</value>
		public decimal ph_quan
		{
			get
			{
				return _ph_quan;
			}

			set
			{
				_ph_quan = value;
				OnPropertyChanged(nameof(ph_quan));
			}
		}

		/// <summary>
		/// Dodatkowy opis
		/// </summary>
		/// <value>The ph desc.</value>
		public string ph_desc
		{
			get
			{
				return _ph_desc;
			}

			set
			{
				_ph_desc = value;
				OnPropertyChanged(nameof(ph_desc));
			}
		}

		/// <summary>
		/// Data zbioru 
		/// </summary>
		/// <value>The ph dateadd.</value>
		public DateTime ph_dateadd
		{
			get
			{
				return _ph_dateadd;
			}

			set
			{
				_ph_dateadd = value;
				OnPropertyChanged(nameof(ph_dateadd));
			}
		}

		public DateTime ph_timestamp
		{
			get
			{
				return _ph_timestamp;
			}

			set
			{
				_ph_timestamp = value;
			}
		}
	}
}
