using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
namespace MojaPasieka.DataModel
{
	/// <summary>
	/// Rasa
	/// </summary>
	[Table("tb_beebreed")]
	public class BeeBreed : DataModelBase, IDataModel, IDataModelSelfInit
	{
		private int _bb_id;
		private string _bb_name;
		private string _bb_desc;
		private DateTime _bb_timestamp;

		/// <summary>
		/// id rasy
		/// </summary>
		/// <value>The bb identifier.</value>
		[PrimaryKey, AutoIncrement]
		public int bb_id
		{
			get
			{
				return _bb_id;
			}

			set
			{
				_bb_id = value;
				OnPropertyChanged(nameof(bb_id));
			}
		}

		/// <summary>
		/// Nazwa rasy
		/// </summary>
		/// <value>The name of the bb.</value>
		public string bb_name
		{
			get
			{
				return _bb_name;
			}

			set
			{
				_bb_name = value;
				OnPropertyChanged(nameof(bb_name));
			}
		}

		/// <summary>
		/// Opis rasy
		/// </summary>
		/// <value>The bb desc.</value>
		public string bb_desc
		{
			get
			{
				return _bb_desc;
			}

			set
			{
				_bb_desc = value;
				OnPropertyChanged(nameof(bb_desc));
			}
		}

		public DateTime bb_timestamp
		{
			get
			{
				return _bb_timestamp;
			}

			set
			{
				_bb_timestamp = value;
				OnPropertyChanged(nameof(bb_timestamp));
			}
		}

		public void FillWithData(SQLiteConnection database)
		{
			var res =  database.ExecuteScalar<int>("SELECT COUNT(bb_id) FROM tb_beebreed");
			if (res == 0)
			{
				 database.InsertAll(new List<BeeBreed> {
					new BeeBreed {
						bb_name = "Kraińska",
						bb_desc = "",
						bb_timestamp = DateTime.Now
					},
					new BeeBreed {
						bb_name = "Kaukaska",
						bb_desc = "",
						bb_timestamp = DateTime.Now
					},
					new BeeBreed {
						bb_name = "Środkowo-Europejska",
						bb_desc = "",
						bb_timestamp = DateTime.Now
					},
					new BeeBreed {
						bb_name = "Buckfast",
						bb_desc = "",
						bb_timestamp = DateTime.Now
					},
					new BeeBreed {
						bb_name = "Włoska",
						bb_desc = "",
						bb_timestamp = DateTime.Now
					},
					new BeeBreed {
						bb_name = "Elgon",
						bb_desc = "",
						bb_timestamp = DateTime.Now
					}
				});
			}

		}
	}
}
