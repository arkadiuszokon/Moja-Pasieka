using System;
using SQLite;
namespace MojaPasieka.DataModel
{
	[Table("tb_scale")]
	public class Scale : DataModelBase, IDataModel
	{

		private int _sc_id;
		private string _sc_name;
		private int _cs_bh_id;
		private DateTime _sc_date;
		private DateTime _sc_timestamp;

		/// <summary>
		/// Id wagi
		/// </summary>
		/// <value>The sc identifier.</value>
		[PrimaryKey, AutoIncrement]
		public int sc_id
		{
			get
			{
				return _sc_id;
			}

			set
			{
				_sc_id = value;
				OnPropertyChanged(nameof(sc_id));
			}
		}

		/// <summary>
		/// Nazwa wagi
		/// </summary>
		/// <value>The name of the sc.</value>
		public string sc_name
		{
			get
			{
				return _sc_name;
			}

			set
			{
				_sc_name = value;
				OnPropertyChanged(nameof(sc_name));
			}
		}

		/// <summary>
		/// id ula
		/// </summary>
		/// <value>The cs bh identifier.</value>
		[Indexed]
		public int cs_bh_id
		{
			get
			{
				return _cs_bh_id;
			}

			set
			{
				_cs_bh_id = value;
				OnPropertyChanged(nameof(cs_bh_id));
			}
		}

		/// <summary>
		/// Data dodania wagi
		/// </summary>
		/// <value>The sc date.</value>
		public DateTime sc_date
		{
			get
			{
				return _sc_date;
			}

			set
			{
				_sc_date = value;
				OnPropertyChanged(nameof(sc_date));
			}
		}

		/// <summary>
		/// Timestamp
		/// </summary>
		/// <value>The sc timestamp.</value>
		public DateTime sc_timestamp
		{
			get
			{
				return _sc_timestamp;
			}

			set
			{
				_sc_timestamp = value;
				OnPropertyChanged(nameof(sc_timestamp));
			}
		}
	}
}
