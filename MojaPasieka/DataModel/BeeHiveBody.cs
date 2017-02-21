using System;
using SQLite;
namespace MojaPasieka.DataModel
{
	[Table("tb_beehivebody")]
	public class BeeHiveBody:DataModelBase, IDataModel
	{
		
		private int _bhb_id;
		private int _bhb_bh_id;
		private int _bhb_wh_id;
		private int _bhb_framescount;
		private int _bhb_ft_id;
		private int _bhb_order;
		private string _bhb_paint;
		private string _bhb_name;
		private string _bhb_desc;
		private DateTime _bhb_timestamp;

		/// <summary>
		/// Id korpusu
		/// </summary>
		/// <value>The bhb identifier.</value>
		[PrimaryKey, AutoIncrement]
		public int bhb_id
		{
			get
			{
				return _bhb_id;
			}

			set
			{
				_bhb_id = value;
				OnPropertyChanged(nameof(bhb_id));
			}
		}

		/// <summary>
		/// Id ula
		/// </summary>
		/// <value>Null jeżeli jest w magazynie</value>
		[Indexed]
		public int bhb_bh_id
		{
			get
			{
				return _bhb_bh_id;
			}

			set
			{
				_bhb_bh_id = value;
				OnPropertyChanged(nameof(bhb_bh_id));
			}
		}

		/// <summary>
		/// Ilość ramek
		/// </summary>
		/// <value>The bhb framescount.</value>
		public int bhb_framescount
		{
			get
			{
				return _bhb_framescount;
			}

			set
			{
				_bhb_framescount = value;
				OnPropertyChanged(nameof(bhb_framescount));
			}
		}

		/// <summary>
		/// Id typu ramki
		/// </summary>
		/// <value>The bhb rt identifier.</value>
		[Indexed]
		public int bhb_ft_id
		{
			get
			{
				return _bhb_ft_id;
			}

			set
			{
				_bhb_ft_id = value;
				OnPropertyChanged(nameof(bhb_ft_id));
			}
		}

		/// <summary>
		/// Kolejność licząc od dennicy
		/// </summary>
		/// <value>The bhb order.</value>
		public int bhb_order
		{
			get
			{
				return _bhb_order;
			}

			set
			{
				_bhb_order = value;
				OnPropertyChanged(nameof(bhb_order));
			}
		}

		/// <summary>
		/// Malowanie korpusu
		/// </summary>
		/// <value>The bhb paint.</value>
		public string bhb_paint
		{
			get
			{
				return _bhb_paint;
			}

			set
			{
				_bhb_paint = value;
				OnPropertyChanged(nameof(bhb_paint));
			}
		}

		/// <summary>
		/// Oznaczenie własne pasieki
		/// </summary>
		/// <value>The name of the bhb.</value>
		public string bhb_name
		{
			get
			{
				return _bhb_name;
			}

			set
			{
				_bhb_name = value;
				OnPropertyChanged(nameof(bhb_name));
			}
		}

		/// <summary>
		/// Dodatkowy opis
		/// </summary>
		/// <value>The bhb desc.</value>
		public string bhb_desc
		{
			get
			{
				return _bhb_desc;
			}

			set
			{
				_bhb_desc = value;
				OnPropertyChanged(nameof(bhb_desc));
			}
		}

		public DateTime bhb_timestamp
		{
			get
			{
				return _bhb_timestamp;
			}

			set
			{
				_bhb_timestamp = value;
				OnPropertyChanged(nameof(bhb_timestamp));
			}
		}

		/// <summary>
		/// Id magazynu
		/// </summary>
		/// <value>null jeżeli jest na ulu</value>
		[Indexed]
		public int bhb_wh_id
		{
			get
			{
				return _bhb_wh_id;
			}

			set
			{
				_bhb_wh_id = value;
			}
		}
	}
}
