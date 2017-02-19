using System;
using SQLite;
namespace MojaPasieka.DataModel
{
	[Table("tb_hivebody")]
	public class HiveBody:DataModelBase, IDataModel
	{
		
		private int _kr_id;
		private int _kr_ul_id;
		private int _kr_framescount;
		private int _kr_rt_id;
		private int _kr_order;
		private string _kr_paint;
		private string _kr_name;
		private string _kr_desc;
		private DateTime _kr_timestamp;

		/// <summary>
		/// Id korpusu
		/// </summary>
		/// <value>The kr identifier.</value>
		[PrimaryKey, AutoIncrement]
		public int kr_id
		{
			get
			{
				return _kr_id;
			}

			set
			{
				_kr_id = value;
				OnPropertyChanged(nameof(kr_id));
			}
		}

		[Indexed]
		public int kr_ul_id
		{
			get
			{
				return _kr_ul_id;
			}

			set
			{
				_kr_ul_id = value;
				OnPropertyChanged(nameof(kr_ul_id));
			}
		}

		/// <summary>
		/// Ilość ramek
		/// </summary>
		/// <value>The kr framescount.</value>
		public int kr_framescount
		{
			get
			{
				return _kr_framescount;
			}

			set
			{
				_kr_framescount = value;
				OnPropertyChanged(nameof(kr_framescount));
			}
		}

		/// <summary>
		/// Id typu ramki
		/// </summary>
		/// <value>The kr rt identifier.</value>
		[Indexed]
		public int kr_rt_id
		{
			get
			{
				return _kr_rt_id;
			}

			set
			{
				_kr_rt_id = value;
				OnPropertyChanged(nameof(kr_rt_id));
			}
		}

		/// <summary>
		/// Kolejność licząc od dennicy
		/// </summary>
		/// <value>The kr order.</value>
		public int kr_order
		{
			get
			{
				return _kr_order;
			}

			set
			{
				_kr_order = value;
				OnPropertyChanged(nameof(kr_order));
			}
		}

		/// <summary>
		/// Malowanie korpusu
		/// </summary>
		/// <value>The kr paint.</value>
		public string kr_paint
		{
			get
			{
				return _kr_paint;
			}

			set
			{
				_kr_paint = value;
				OnPropertyChanged(nameof(kr_paint));
			}
		}

		/// <summary>
		/// Oznaczenie własne pasieki
		/// </summary>
		/// <value>The name of the kr.</value>
		public string kr_name
		{
			get
			{
				return _kr_name;
			}

			set
			{
				_kr_name = value;
				OnPropertyChanged(nameof(kr_name));
			}
		}

		/// <summary>
		/// Dodatkowy opis
		/// </summary>
		/// <value>The kr desc.</value>
		public string kr_desc
		{
			get
			{
				return _kr_desc;
			}

			set
			{
				_kr_desc = value;
				OnPropertyChanged(nameof(kr_desc));
			}
		}

		public DateTime kr_timestamp
		{
			get
			{
				return _kr_timestamp;
			}

			set
			{
				_kr_timestamp = value;
				OnPropertyChanged(nameof(kr_timestamp));
			}
		}
	}
}
