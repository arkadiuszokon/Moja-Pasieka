using System;
using SQLite;
namespace MojaPasieka.DataModel
{
	/// <summary>
	/// Ocena stanu rodziny
	/// </summary>
	[Table("tb_beecolonycondition")]
	public class BeeColonyCondition : DataModelBase, IDataModel
	{

		private int _bcc_id;
		private int _bcc_bc_id;
		private int _bcc_strenght;
		private int _bcc_maggotscount;
		private int _bcc_honeycount;
		private int _bcc_pergacount;
		private int _bcc_swarmready;
		private int _bcc_agressive;
		private int _bcc_sticking;
		private int _bcc_healthy;
		private int _bcc_additional;
		private DateTime _bcc_date;
		private DateTime _bcc_timestamp;

		/// <summary>
		/// Id oceny rodziny
		/// </summary>
		/// <value>The bcc identifier.</value>
		[PrimaryKey, AutoIncrement]
		public int bcc_id
		{
			get
			{
				return _bcc_id;
			}

			set
			{
				_bcc_id = value;
				OnPropertyChanged(nameof(bcc_id));
			}
		}
		/// <summary>
		/// Id rodziny
		/// </summary>
		/// <value>The bcc bc identifier.</value>
		[Indexed]
		public int bcc_bc_id
		{
			get
			{
				return _bcc_bc_id;
			}

			set
			{
				_bcc_bc_id = value;
				OnPropertyChanged(nameof(bcc_bc_id));
			}
		}

		/// <summary>
		/// Siła rodziny
		/// </summary>
		/// <value>The bcc strenght.</value>
		public int bcc_strenght
		{
			get
			{
				return _bcc_strenght;
			}

			set
			{
				_bcc_strenght = value;
				OnPropertyChanged(nameof(bcc_strenght));
			}
		}

		/// <summary>
		/// Ilość czerwiu
		/// </summary>
		/// <value>The bcc maggotscount.</value>
		public int bcc_maggotscount
		{
			get
			{
				return _bcc_maggotscount;
			}

			set
			{
				_bcc_maggotscount = value;
				OnPropertyChanged(nameof(bcc_maggotscount));
			}
		}

		/// <summary>
		/// Ilość miodu
		/// </summary>
		/// <value>The bcc honeycount.</value>
		public int bcc_honeycount
		{
			get
			{
				return _bcc_honeycount;
			}

			set
			{
				_bcc_honeycount = value;
				OnPropertyChanged(nameof(bcc_honeycount));
			}
		}

		/// <summary>
		/// Nastrój rojowy
		/// </summary>
		/// <value>The bcc swarmready.</value>
		public int bcc_swarmready
		{
			get
			{
				return _bcc_swarmready;
			}

			set
			{
				_bcc_swarmready = value;
				OnPropertyChanged(nameof(bcc_swarmready));
			}
		}

		/// <summary>
		/// Agresywność
		/// </summary>
		/// <value>The bcc agressive.</value>
		public int bcc_agressive
		{
			get
			{
				return _bcc_agressive;
			}

			set
			{
				_bcc_agressive = value;
				OnPropertyChanged(nameof(bcc_agressive));
			}
		}

		/// <summary>
		/// Trzymanie się plastra
		/// </summary>
		/// <value>The bcc sticking.</value>
		public int bcc_sticking
		{
			get
			{
				return _bcc_sticking;
			}

			set
			{
				_bcc_sticking = value;
				OnPropertyChanged(nameof(bcc_sticking));
			}
		}

		/// <summary>
		/// Zdrowie rodziny
		/// </summary>
		/// <value>The bcc healthy.</value>
		public int bcc_healthy
		{
			get
			{
				return _bcc_healthy;
			}

			set
			{
				_bcc_healthy = value;
				OnPropertyChanged(nameof(bcc_healthy));
			}
		}

		/// <summary>
		/// Dodatkowe pole
		/// </summary>
		/// <value>The bcc additional.</value>
		public int bcc_additional
		{
			get
			{
				return _bcc_additional;
			}

			set
			{
				_bcc_additional = value;
				OnPropertyChanged(nameof(bcc_additional));
			}
		}

		/// <summary>
		/// Data oceny
		/// </summary>
		/// <value>The bcc date.</value>
		public DateTime bcc_date
		{
			get
			{
				return _bcc_date;
			}

			set
			{
				_bcc_date = value;
				OnPropertyChanged(nameof(bcc_date));
			}
		}

		/// <summary>
		/// Timestamp
		/// </summary>
		/// <value>The bcc timestamp.</value>
		public DateTime bcc_timestamp
		{
			get
			{
				return _bcc_timestamp;
			}

			set
			{
				_bcc_timestamp = value;
				OnPropertyChanged(nameof(bcc_timestamp));
			}
		}

		/// <summary>
		/// Ilość pierzgi
		/// </summary>
		/// <value>The bcc pergacount.</value>
		public int bcc_pergacount
		{
			get
			{
				return _bcc_pergacount;
			}

			set
			{
				_bcc_pergacount = value;
				OnPropertyChanged(nameof(bcc_pergacount));
			}
		}
	}
}
