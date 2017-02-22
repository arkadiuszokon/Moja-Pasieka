using System;
using SQLite;
namespace MojaPasieka.DataModel
{
	/// <summary>
	/// Obiekt magazynu
	/// </summary>
	[Table("tb_warehouse")]
	public class Warehouse : DataModelBase, IDataModel
	{

		private int _wh_id;
		private string _wh_name;
		private string _wh_desc;
		private DateTime _wh_timestamp;

		/// <summary>
		/// Id magazynu
		/// </summary>
		/// <value>The wh identifier.</value>
		[PrimaryKey, AutoIncrement]
		public int wh_id
		{
			get
			{
				return _wh_id;
			}

			set
			{
				_wh_id = value;
				OnPropertyChanged(nameof(wh_id));
			}
		}

		/// <summary>
		/// Nazwa magazynu
		/// </summary>
		/// <value>The name of the wh.</value>
		public string wh_name
		{
			get
			{
				return _wh_name;
			}

			set
			{
				_wh_name = value;
				OnPropertyChanged(nameof(wh_name));
			}
		}

		/// <summary>
		/// Opis magazynu
		/// </summary>
		/// <value>The wh desc.</value>
		public string wh_desc
		{
			get
			{
				return _wh_desc;
			}

			set
			{
				_wh_desc = value;
				OnPropertyChanged(nameof(wh_desc));
			}
		}

		/// <summary>
		/// Timestamp
		/// </summary>
		/// <value>The wh timestamp.</value>
		public DateTime wh_timestamp
		{
			get
			{
				return _wh_timestamp;
			}

			set
			{
				_wh_timestamp = value;
			}
		}
	}
}
