﻿using System;
using System.Threading.Tasks;

namespace MojaPasieka.cqrs
{
	public interface IQueryBus
	{
		TResult Process<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
	}
}
