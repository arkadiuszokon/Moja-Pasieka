using System;
using System.Collections.Generic;
using SQLite;

namespace MojaPasieka.DataModel
{
	/// <summary>
	/// Pokarm
	/// </summary>
	[Table("tb_feed")]
	public class Feed : DataModelBase, IDataModel
	{

		private int _fd_id;
		private int _fd_ft_id;
		private int _fd_wh_id;
		private FeedSource _fd_source;
		private decimal _fd_quan;
		private string _fd_desc;
		private DateTime _fd_expdate;
		private DateTime _fd_timestamp;

		/// <summary>
		/// Id pokarmu
		/// </summary>
		/// <value>The fd identifier.</value>
		[PrimaryKey, AutoIncrement]
		public int fd_id
		{
			get
			{
				return _fd_id;
			}

			set
			{
				_fd_id = value;
				OnPropertyChanged(nameof(fd_id));
			}
		}

		/// <summary>
		/// Id typu pokarmu
		/// </summary>
		/// <value>The fd ft identifier.</value>
		[Indexed]
		public int fd_ft_id
		{
			get
			{
				return _fd_ft_id;
			}

			set
			{
				_fd_ft_id = value;
				OnPropertyChanged(nameof(fd_ft_id));
			}
		}

		/// <summary>
		/// Id magazynu
		/// </summary>
		/// <value>The fd wh identifier.</value>
		[Indexed]
		public int fd_wh_id
		{
			get
			{
				return _fd_wh_id;
			}

			set
			{
				_fd_wh_id = value;
				OnPropertyChanged(nameof(fd_wh_id));
			}
		}

		/// <summary>
		/// Zródło pokarmu
		/// </summary>
		/// <value>The fd source.</value>
		public FeedSource fd_source
		{
			get
			{
				return _fd_source;
			}

			set
			{
				_fd_source = value;
				OnPropertyChanged(nameof(fd_source));
			}
		}

		/// <summary>
		/// Posiadana ilość
		/// </summary>
		/// <value>The fd quan.</value>
		public decimal fd_quan
		{
			get
			{
				return _fd_quan;
			}

			set
			{
				_fd_quan = value;
				OnPropertyChanged(nameof(fd_quan));
			}
		}

		/// <summary>
		/// Dodatkowy opis
		/// </summary>
		/// <value>The fd desc.</value>
		public string fd_desc
		{
			get
			{
				return _fd_desc;
			}

			set
			{
				_fd_desc = value;
				OnPropertyChanged(nameof(fd_desc));
			}
		}

		/// <summary>
		/// Data ważności
		/// </summary>
		/// <value>The fd expdate.</value>
		public DateTime fd_expdate
		{
			get
			{
				return _fd_expdate;
			}

			set
			{
				_fd_expdate = value;
				OnPropertyChanged(nameof(fd_expdate));
			}
		}


		public DateTime fd_timestamp
		{
			get
			{
				return _fd_timestamp;
			}

			set
			{
				_fd_timestamp = value;
			}
		}
	}

	public enum FeedSource
	{
		[EnumName("Kupiony")]
		BUYED = 1,

		[EnumName("Własna produkcja")]
		OWN_PRODUCTION = 2
	}
}
