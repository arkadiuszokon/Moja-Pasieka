using System;
namespace MojaPasieka.cqrs
{
	public class CheckExists : IQuery<bool>
	{
		public Type DataModelType { get; protected set; }

		public int PrimaryKey { get; protected set; }

		public CheckExists(Type dataModelType, int primaryKey)
		{
			this.DataModelType = dataModelType;
			this.PrimaryKey = primaryKey;
		}
	}
}
