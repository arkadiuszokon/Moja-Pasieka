using System;
using System.Threading.Tasks;

namespace MojaPasieka.DataModel
{
	public interface IDataModelSelfInit
	{
		Task fillWithData(SQLite.SQLiteAsyncConnection database);
	}
}
