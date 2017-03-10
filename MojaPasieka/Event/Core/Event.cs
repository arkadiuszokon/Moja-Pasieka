using System;
using MojaPasieka.DataModel;
namespace MojaPasieka.cqrs
{
	/// <summary>
	/// CRUDowe eventy opakowane w generyka
	/// </summary>
	public class Event<TData> : IEvent where TData : DataModelBase
	{

		public TData Item { get; protected set; }

		public EventAction Action { get; protected set; }

		public Event(TData item, EventAction action)
		{
			this.Action = action;
			this.Item = item;
		}
	}

	public enum EventAction
	{
		CREATE = 1,
		UPDATE= 2,
		DELETE = 3
	}
}
