using System;
using SQLite;
namespace MojaPasieka.DataModel
{
	/// <summary>
	/// Historia ramki
	/// </summary>
	[Table("tb_framehistory")]
	public class FrameHistory : DataModelBase, IDataModel
	{

		private int _fh_id;
		private int _fh_fr_id;
		private int _fr_fht_id;
		private string _fr_desc;
		private int _fr_maggotscount;
		private int _fr_honeycount;
		private int _fr_pergacount;
		private int _fr_timestamp;

		/// <summary>
		/// Id wpisu do historii
		/// </summary>
		/// <value>The fh identifier.</value>
		[PrimaryKey, AutoIncrement]
		public int fh_id
		{
			get
			{
				return _fh_id;
			}

			set
			{
				_fh_id = value;
				OnPropertyChanged(nameof(fh_id));
			}
		}

		/// <summary>
		/// Id ramki
		/// </summary>
		/// <value>The fh fr identifier.</value>
		[Indexed]
		public int fh_fr_id
		{
			get
			{
				return _fh_fr_id;
			}

			set
			{
				_fh_fr_id = value;
				OnPropertyChanged(nameof(fh_fr_id));
			}
		}

		/// <summary>
		/// Id typu z historii
		/// </summary>
		/// <value>The fr fht identifier.</value>
		[Indexed]
		public int fr_fht_id
		{
			get
			{
				return _fr_fht_id;
			}

			set
			{
				_fr_fht_id = value;
				OnPropertyChanged(nameof(fr_fht_id));
			}
		}

		/// <summary>
		/// Dodatkowy opis
		/// </summary>
		/// <value>The fr desc.</value>
		public string fr_desc
		{
			get
			{
				return _fr_desc;
			}

			set
			{
				_fr_desc = value;
				OnPropertyChanged(nameof(fr_desc));
			}
		}

		/// <summary>
		/// Ilość czerwiu
		/// </summary>
		/// <value>The fr maggotscount.</value>
		public int fr_maggotscount
		{
			get
			{
				return _fr_maggotscount;
			}

			set
			{
				_fr_maggotscount = value;
				OnPropertyChanged(nameof(fr_maggotscount));
			}
		}

		/// <summary>
		/// Ilość miodu/pokarmu
		/// </summary>
		/// <value>The fr honeycount.</value>
		public int fr_honeycount
		{
			get
			{
				return _fr_honeycount;
			}

			set
			{
				_fr_honeycount = value;
				OnPropertyChanged(nameof(fr_honeycount));
			}
		}

		/// <summary>
		/// Ilość pierzgi
		/// </summary>
		/// <value>The fr pergacount.</value>
		public int fr_pergacount
		{
			get
			{
				return _fr_pergacount;
			}

			set
			{
				_fr_pergacount = value;
				OnPropertyChanged(nameof(fr_pergacount));
			}
		}

		/// <summary>
		/// Timestamp
		/// </summary>
		/// <value>The fr timestamp.</value>
		public int fr_timestamp
		{
			get
			{
				return _fr_timestamp;
			}

			set
			{
				_fr_timestamp = value;
			}
		}


	}
}
