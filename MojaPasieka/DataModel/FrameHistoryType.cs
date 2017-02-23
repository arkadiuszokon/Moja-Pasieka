using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
namespace MojaPasieka.DataModel
{
	/// <summary>
	/// Historia ramki
	/// </summary>
	[Table("tb_framehistorytype")]
	public class FrameHistoryType: DataModelBase, IDataModel, IDataModelSelfInit
	{


		private int _fht_id;
		private string _fht_name;
		private DateTime _fht_timestamp;

		/// <summary>
		/// Id wpisu typu historii ramki
		/// </summary>
		/// <value>The fht identifier.</value>
		[PrimaryKey, AutoIncrement]
		public int fht_id
		{
			get
			{
				return _fht_id;
			}

			set
			{
				_fht_id = value;
				OnPropertyChanged(nameof(fht_id));
			}
		}

		/// <summary>
		/// Nazwa typu
		/// </summary>
		/// <value>The name of the fht.</value>
		public string fht_name
		{
			get
			{
				return _fht_name;
			}

			set
			{
				_fht_name = value;
				OnPropertyChanged(nameof(fht_name));
			}
		}

		public DateTime fht_timestamp
		{
			get
			{
				return _fht_timestamp;
			}

			set
			{
				_fht_timestamp = value;
			}
		}

		public void FillWithData(SQLiteConnection database)
		{
			var res = database.ExecuteScalar<int>("SELECT COUNT(fht_id) FROM tb_framehistorytype");
			if (res == 0)
			{
				database.InsertAll(new List<FrameHistoryType> {

					new FrameHistoryType {
						fht_name = "Pusta ramka",
						fht_timestamp = DateTime.Now
					},
					new FrameHistoryType {
						fht_name = "Ramka z węzą",
						fht_timestamp = DateTime.Now
					},
					new FrameHistoryType {
						fht_name = "Węza w budowie",
						fht_timestamp = DateTime.Now
					},
					new FrameHistoryType {
						fht_name = "Do przetopu",
						fht_timestamp = DateTime.Now
					}

				
				});
			}
		}
	}
}
