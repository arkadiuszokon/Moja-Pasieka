using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
namespace MojaPasieka.DataModel
{
	/// <summary>
	/// Typ pokarmu
	/// </summary>
	[Table("tb_feedtype")]
	public class FeedType : DataModelBase, IDataModel, IDataModelSelfInit
	{
		
		private int _ft_id;
		private string _ft_name;
		private string _ft_uom;
		private string _ft_desc;
		private DateTime _ft_timestamp;

		/// <summary>
		/// Id typu pokarmu
		/// </summary>
		/// <value>The ft identifier.</value>
		[PrimaryKey, AutoIncrement]
		public int ft_id
		{
			get
			{
				return _ft_id;
			}

			set
			{
				_ft_id = value;
				OnPropertyChanged(nameof(ft_id));
			}
		}

		/// <summary>
		/// Nazwa pokarmu
		/// </summary>
		/// <value>The name of the ft.</value>
		public string ft_name
		{
			get
			{
				return _ft_name;
			}

			set
			{
				_ft_name = value;
				OnPropertyChanged(nameof(ft_name));
			}
		}

		/// <summary>
		/// Jednostka miary pokarmu
		/// </summary>
		/// <value>The ft uom.</value>
		public string ft_uom
		{
			get
			{
				return _ft_uom;
			}

			set
			{
				_ft_uom = value;
				OnPropertyChanged(nameof(ft_uom));
			}
		}

		/// <summary>
		/// Dodatkowy opis
		/// </summary>
		/// <value>The ft desc.</value>
		public string ft_desc
		{
			get
			{
				return _ft_desc;
			}

			set
			{
				_ft_desc = value;
				OnPropertyChanged(nameof(ft_desc));
			}
		}

		public DateTime ft_timestamp
		{
			get
			{
				return _ft_timestamp;
			}

			set
			{
				_ft_timestamp = value;
			}
		}

		public void fillWithData(SQLiteConnection database)
		{
			var res = database.ExecuteScalar<int>("SELECT COUNT(ft_id) FROM tb_feedtype");
			if (res == 0)
			{
				database.InsertAll(new List<FeedType>
				{
					new FeedType {
						ft_name="Syrop cukrowy 1:1",
						ft_uom="litr",
						ft_desc="",
						ft_timestamp = DateTime.Now
					},
					new FeedType {
						ft_name="Syrop cukrowy 2:1",
						ft_uom="litr",
						ft_desc="",
						ft_timestamp = DateTime.Now
					},
					new FeedType {
						ft_name="Syrop cukrowy 3:2",
						ft_uom="litr",
						ft_desc="",
						ft_timestamp = DateTime.Now
					},
					new FeedType {
						ft_name="Inwert",
						ft_uom="litr",
						ft_desc="",
						ft_timestamp = DateTime.Now
					},
					new FeedType {
						ft_name="Fondant",
						ft_uom="kg",
						ft_desc="",
						ft_timestamp = DateTime.Now
					},
					new FeedType {
						ft_name="Ciasto cukrowe",
						ft_uom="kg",
						ft_desc="",
						ft_timestamp = DateTime.Now
					},
					new FeedType {
						ft_name="Ciasto cukrowe z pyłkiem",
						ft_uom="kg",
						ft_desc="",
						ft_timestamp = DateTime.Now
					}
				});
			}
		}
	}
}
