using System;
using System.Threading.Tasks;

namespace MojaPasieka.DataModel
{
	public interface IDataModelSelfInit
	{
		void fillWithData(SQLite.SQLiteConnection database);
	}
}
