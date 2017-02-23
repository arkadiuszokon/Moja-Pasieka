using System;
using SQLite;

namespace MojaPasieka.DataModel
{
	[Table("tb_pollentrap")]
	public class PollenTrap:DataModelBase, IDataModel
	{
		/*new Column("pl_id", "INTEGER", "", true, true, true),
				new Column("pl_name", "VARCHAR", "100", false),
				new Column("pl_ul_id", "INTEGER", "", true), //id ula na którym założony jest poławiacz
				new Column("pl_dateadded", "INTEGER", "", true), //data założenia poławiacza
				new Column("pl_timestamp", "INTEGER", "", true)*/
		private int _pt_id;
		private string _pt_name;
		private int _pt_bh_id;
		private DateTime _pt_dateadded;
		private DateTime _pt_timestamp;

		[PrimaryKey, AutoIncrement]
		public int pt_id
		{
			get
			{
				return _pt_id;
			}

			set
			{
				_pt_id = value;
				OnPropertyChanged(nameof(pt_id));
			}
		}

		/// <summary>
		/// Nazwa połąwiacz/oznaczenie własne
		/// </summary>
		/// <value>The name of the point.</value>
		public string pt_name
		{
			get
			{
				return _pt_name;
			}

			set
			{
				_pt_name = value;
				OnPropertyChanged(nameof(pt_name));
			}
		}

		/// <summary>
		/// Id ula na którym założony jest poławiacz
		/// </summary>
		/// <value>The point bh identifier.</value>
		[Indexed]
		public int pt_bh_id
		{
			get
			{
				return _pt_bh_id;
			}

			set
			{
				_pt_bh_id = value;
				OnPropertyChanged(nameof(pt_bh_id));
			}
		}

		/// <summary>
		/// Data założenia
		/// </summary>
		/// <value>The point dateadded.</value>
		public DateTime pt_dateadded
		{
			get
			{
				return _pt_dateadded;
			}

			set
			{
				_pt_dateadded = value;
				OnPropertyChanged(nameof(pt_dateadded));
			}
		}

		public DateTime pt_timestamp
		{
			get
			{
				return _pt_timestamp;
			}

			set
			{
				_pt_timestamp = value;
			}
		}
	}
}
