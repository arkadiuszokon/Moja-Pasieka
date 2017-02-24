using System;

namespace MojaPasieka.cqrs
{
	public class GetNumOfRowsInTable : IQuery<int>
	{
		public Type dataModel { get; private set; }

		public GetNumOfRowsInTable(Type dataModel)
		{
			this.dataModel = dataModel;
		}
	}
}
