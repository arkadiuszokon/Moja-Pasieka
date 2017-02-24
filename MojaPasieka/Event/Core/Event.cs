using System;
using MojaPasieka.DataModel;
namespace MojaPasieka.cqrs
{
	/// <summary>
	/// CRUDowe eventy opakowane w generyka
	/// </summary>
	public class Event<TData> : IEvent where TData : DataModelBase
	{

		public TData item { get; private set; }

		public EventAction action { get; private set; }

		public Event(TData item, EventAction action)
		{
			this.action = action;
			this.item = item;
		}
	}


	public enum EventAction
	{
		CREATE = 1,
		UPDATE= 2,
		DELETE = 3
	}
}
