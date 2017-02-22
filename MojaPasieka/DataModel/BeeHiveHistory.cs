using System;
using SQLite;
namespace MojaPasieka.DataModel
{
	/// <summary>
	/// Historia ula
	/// </summary>
	[Table("tb_beehivehistory")]
	public class BeeHiveHistory : DataModelBase, IDataModel
	{
		
		private int _bhh_id;
		private int _bhh_bh_id;
		private int _bhh_bhht_id;
		private string _bhh_desc;
		private DateTime _bhh_date;
		private DateTime _bhh_timestamp;

		/// <summary>
		/// Id wpisu historii ula
		/// </summary>
		/// <value>The bhh identifier.</value>
		[PrimaryKey, AutoIncrement]
		public int bhh_id
		{
			get
			{
				return _bhh_id;
			}

			set
			{
				_bhh_id = value;
				OnPropertyChanged(nameof(bhh_id));
			}
		}

		/// <summary>
		/// Id ula
		/// </summary>
		/// <value>The bhh bh identifier.</value>
		[Indexed]
		public int bhh_bh_id
		{
			get
			{
				return _bhh_bh_id;
			}

			set
			{
				_bhh_bh_id = value;
				OnPropertyChanged(nameof(bhh_id));
			}
		}

		/// <summary>
		/// Id typu wpisu z historii
		/// </summary>
		/// <value>The bhh bhht identifier.</value>
		[Indexed]
		public int bhh_bhht_id
		{
			get
			{
				return _bhh_bhht_id;
			}

			set
			{
				_bhh_bhht_id = value;
				OnPropertyChanged(nameof(bhh_bhht_id));
			}
		}

		/// <summary>
		/// Data wpisu
		/// </summary>
		/// <value>The bhh date.</value>
		public DateTime bhh_date
		{
			get
			{
				return _bhh_date;
			}

			set
			{
				_bhh_date = value;
				OnPropertyChanged(nameof(bhh_date));
			}
		}

		/// <summary>
		/// timestamp
		/// </summary>
		/// <value>The bhh timestamp.</value>
		public DateTime bhh_timestamp
		{
			get
			{
				return _bhh_timestamp;
			}

			set
			{
				_bhh_timestamp = value;
				OnPropertyChanged(nameof(bhh_timestamp));
			}
		}

		/// <summary>
		/// Dodatkowe uwagi
		/// </summary>
		/// <value>The bhh desc.</value>
		public string bhh_desc
		{
			get
			{
				return _bhh_desc;
			}

			set
			{
				_bhh_desc = value;
				OnPropertyChanged(nameof(bhh_desc));
			}
		}
	}
}
