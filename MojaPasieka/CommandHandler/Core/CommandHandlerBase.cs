using System;
using SQLite;

namespace MojaPasieka.cqrs
{
	public class CommandHandlerBase
	{
		public SQLiteConnection Connection { get; set; }
		public IEventPublisher EventPublisher { get; set; }
	}
}
