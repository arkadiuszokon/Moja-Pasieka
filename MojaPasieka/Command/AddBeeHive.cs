﻿using System;
using MojaPasieka.DataModel;

namespace MojaPasieka.cqrs
{
	public class AddBeeHive : ICommandAsync
	{
		public readonly BeeHive beeHive; 

		public AddBeeHive(BeeHive beeHive)
		{
			this.beeHive = beeHive;
		}
	}
}
