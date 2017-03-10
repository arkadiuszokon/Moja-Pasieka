using System;
using SQLite;

namespace MojaPasieka.DataModel
{
	/// <summary>
	/// wpis z historii rodziny
	/// </summary>
	[Table("tb_beecolonyhistory")]
	public class BeeColonyHistory : DataModelBase, IDataModel
	{

		private int _bch_id;
		private int _bch_bc_id;
		private int _bch_bcht_id;
		private string _bch_data;
		private DateTime _bch_date;
		private string _bch_note;
		private DateTime _bch_timestamp;

		/// <summary>
		/// Id wpisu do historii
		/// </summary>
		/// <value>The bch identifier.</value>
		[PrimaryKey, AutoIncrement]
		public int bch_id
		{
			get
			{
				return _bch_id;
			}

			set
			{
				_bch_id = value;
				OnPropertyChanged(nameof(bch_id));
			}
		}

		/// <summary>
		/// Id typu wpisu 
		/// </summary>
		/// <value>The bch bcht identifier.</value>
		[Indexed]
		public int bch_bcht_id
		{
			get
			{
				return _bch_bcht_id;
			}

			set
			{
				_bch_bcht_id = value;
				OnPropertyChanged(nameof(bch_bcht_id));
			}
		}

		/// <summary>
		/// Data wydarzenia wpisu
		/// </summary>
		/// <value>The bch date.</value>
		public DateTime bch_date
		{
			get
			{
				return _bch_date;
			}

			set
			{
				_bch_date = value;
				OnPropertyChanged(nameof(bch_date));
			}
		}

		/// <summary>
		/// Dodatkowe uwagi
		/// </summary>
		/// <value>The bch note.</value>
		public string bch_note
		{
			get
			{
				return _bch_note;
			}

			set
			{
				_bch_note = value;
				OnPropertyChanged(nameof(bch_note));
			}
		}

		public DateTime bch_timestamp
		{
			get
			{
				return _bch_timestamp;
			}

			set
			{
				_bch_timestamp = value;
				OnPropertyChanged(nameof(bch_timestamp));
			}
		}

		/// <summary>
		/// Id rodziny której wpis dotyczy
		/// </summary>
		/// <value>The bch bc identifier.</value>
		[Indexed]
		public int bch_bc_id
		{
			get
			{
				return _bch_bc_id;
			}

			set
			{
				_bch_bc_id = value;
				OnPropertyChanged(nameof(bch_bc_id));
			}
		}
		/// <summary>
		/// Dodatkowe dane wpisu
		/// </summary>
		/// <value>The bch data.</value>
		public string bch_data
		{
			get
			{
				return _bch_data;
			}

			set
			{
				_bch_data = value;
				OnPropertyChanged(nameof(bch_data));
			}
		}
	}
}
