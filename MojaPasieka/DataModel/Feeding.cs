using System;
using SQLite;

namespace MojaPasieka.DataModel
{
	/// <summary>
	/// Podkarmianie
	/// </summary>
	[Table("tb_feeding")]
	public class Feeding : DataModelBase, IDataModel
	{

		private int _fdg_id;
		private int _fdg_bc_id;
		private int _fdg_fd_id;
		private decimal _fdg_quan;
		private DateTime _fdg_date;
		private DateTime _fdg_timestamp;

		[PrimaryKey, AutoIncrement]
		public int fdg_id
		{
			get
			{
				return _fdg_id;
			}

			set
			{
				_fdg_id = value;
				OnPropertyChanged(nameof(fdg_id));
			}
		}

		/// <summary>
		/// Id rodziny którą podkarmiamy
		/// </summary>
		/// <value>The fdg bc identifier.</value>
		[Indexed]
		public int fdg_bc_id
		{
			get
			{
				return _fdg_bc_id;
			}

			set
			{
				_fdg_bc_id = value;
				OnPropertyChanged(nameof(fdg_bc_id));
			}
		}

		/// <summary>
		/// Id pokarmu
		/// </summary>
		/// <value>The fdg fd identifier.</value>
		[Indexed]
		public int fdg_fd_id
		{
			get
			{
				return _fdg_fd_id;
			}

			set
			{
				_fdg_fd_id = value;
				OnPropertyChanged(nameof(fdg_fd_id));
			}
		}

		/// <summary>
		/// Ilość podana
		/// </summary>
		/// <value>The fdg quan.</value>
		public decimal fdg_quan
		{
			get
			{
				return _fdg_quan;
			}

			set
			{
				_fdg_quan = value;
				OnPropertyChanged(nameof(fdg_quan));
			}
		}

		/// <summary>
		/// Data podkarmiania
		/// </summary>
		/// <value>The fdg date.</value>
		public DateTime fdg_date
		{
			get
			{
				return _fdg_date;
			}

			set
			{
				_fdg_date = value;
				OnPropertyChanged(nameof(fdg_date));
			}
		}

		public DateTime fdg_timestamp
		{
			get
			{
				return _fdg_timestamp;
			}

			set
			{
				_fdg_timestamp = value;
			}
		}
	}
}
