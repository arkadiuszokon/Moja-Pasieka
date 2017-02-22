using System;
using SQLite;

namespace MojaPasieka.DataModel
{
	/// <summary>
	/// Miodobranie
	/// </summary>
	[Table("tb_honeyharvest")]
	public class HoneyHarvest : DataModelBase, IDataModel
	{

		private int _hh_id;
		private int _hh_rd_id;
		private int _hh_framescount;
		private int _hh_sheathing;
		private int _hh_quantity;
		private DateTime _hh_date;
		private DateTime _hh_timestamp;

		/// <summary>
		/// id miodobrania
		/// </summary>
		/// <value>The hh identifier.</value>
		[PrimaryKey, AutoIncrement]
		public int hh_id
		{
			get
			{
				return _hh_id;
			}

			set
			{
				_hh_id = value;
				OnPropertyChanged(nameof(hh_id));
			}
		}



		/// <summary>
		/// ilość zabranych ramek
		/// </summary>
		/// <value>The hh framescount.</value>
		public int hh_framescount
		{
			get
			{
				return _hh_framescount;
			}

			set
			{
				_hh_framescount = value;
				OnPropertyChanged(nameof(hh_framescount));
			}
		}

		/// <summary>
		/// Procentowe poszycie ramkek z miodem
		/// </summary>
		/// <value>The hh sheathing.</value>
		public int hh_sheathing
		{
			get
			{
				return _hh_sheathing;
			}

			set
			{
				_hh_sheathing = value;
				OnPropertyChanged(nameof(hh_sheathing));
			}
		}

		/// <summary>
		/// Id rodziny
		/// </summary>
		/// <value>The hh rd identifier.</value>
		[Indexed]
		public int hh_rd_id
		{
			get
			{
				return _hh_rd_id; 
			}

			set
			{
				_hh_rd_id = value;
				OnPropertyChanged(nameof(hh_rd_id));
			}
		}

		/// <summary>
		/// ilość zebranego miodu
		/// </summary>
		/// <value>The hh quantity.</value>
		public int hh_quantity
		{
			get
			{
				return _hh_quantity;
			}

			set
			{
				_hh_quantity = value;
				OnPropertyChanged(nameof(hh_quantity));
			}
		}

		/// <summary>
		/// data miodobrania
		/// </summary>
		/// <value>The hh date.</value>
		public DateTime hh_date
		{
			get
			{
				return _hh_date;
			}

			set
			{
				_hh_date = value;
				OnPropertyChanged(nameof(hh_date));
			}
		}

		public DateTime hh_timestamp
		{
			get
			{
				return _hh_timestamp;
			}

			set
			{
				_hh_timestamp = value;
				OnPropertyChanged(nameof(hh_timestamp));
			}
		}


	}
}
