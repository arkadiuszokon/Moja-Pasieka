using System;
using SQLite;

namespace MojaPasieka.DataModel
{
	[Table("tb_honeyharvest")]
	public class HoneyHarvest : DataModelBase, IDataModel
	{

		
		public HoneyHarvest()
		{
		}



		private int _md_id;
		private int _md_rd_id;
		private int _md_framescount;
		private int _md_sheathing;
		private int _md_quantity;
		private DateTime _md_date;
		private DateTime _md_timestamp;

		/// <summary>
		/// id miodobrania
		/// </summary>
		/// <value>The md identifier.</value>
		[PrimaryKey, AutoIncrement]
		public int md_id
		{
			get
			{
				return _md_id;
			}

			set
			{
				_md_id = value;
				OnPropertyChanged(nameof(md_id));
			}
		}



		/// <summary>
		/// ilość zabranych ramek
		/// </summary>
		/// <value>The md framescount.</value>
		public int md_framescount
		{
			get
			{
				return _md_framescount;
			}

			set
			{
				_md_framescount = value;
				OnPropertyChanged(nameof(md_framescount));
			}
		}

		/// <summary>
		/// Procentowe poszycie ramkek z miodem
		/// </summary>
		/// <value>The md sheathing.</value>
		public int md_sheathing
		{
			get
			{
				return _md_sheathing;
			}

			set
			{
				_md_sheathing = value;
				OnPropertyChanged(nameof(md_sheathing));
			}
		}

		/// <summary>
		/// Id rodziny
		/// </summary>
		/// <value>The md rd identifier.</value>
		[Indexed]
		public int md_rd_id
		{
			get
			{
				return _md_rd_id;
			}

			set
			{
				_md_rd_id = value;
				OnPropertyChanged(nameof(md_rd_id));
			}
		}

		/// <summary>
		/// ilość zebranego miodu
		/// </summary>
		/// <value>The md quantity.</value>
		public int md_quantity
		{
			get
			{
				return _md_quantity;
			}

			set
			{
				_md_quantity = value;
				OnPropertyChanged(nameof(md_quantity));
			}
		}

		/// <summary>
		/// data miodobrania
		/// </summary>
		/// <value>The md date.</value>
		public DateTime md_date
		{
			get
			{
				return _md_date;
			}

			set
			{
				_md_date = value;
				OnPropertyChanged(nameof(md_date));
			}
		}

		public DateTime md_timestamp
		{
			get
			{
				return _md_timestamp;
			}

			set
			{
				_md_timestamp = value;
				OnPropertyChanged(nameof(md_timestamp));
			}
		}


	}
}
