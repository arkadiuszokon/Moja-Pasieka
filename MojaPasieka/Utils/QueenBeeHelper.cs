﻿using System;
using MojaPasieka.DataModel;

namespace MojaPasieka.Utils
{
	public static class QueenBeeHelper
	{
		/// <summary>
		/// Zamiana roku urodzenia na kolor opalitka
		/// </summary>
		/// <returns>The color by year.</returns>
		/// <param name="year">Year.</param>
		public static QueenBeeColor getColorByYear(int year)
		{
			var strYear = year.ToString();
			if (strYear.Length == 4)
			{
				int yearEnd = int.Parse(strYear[3].ToString());
				foreach (var item in QueenBee.queenBeeColorYears)
				{
					for (int i = 0; i < item.Value.Length; i++)
					{
						if (item.Value[i] == yearEnd)
						{
							return item.Key;
						}
					}
				}
			}

			return QueenBeeColor.WHITE;

		}
	}
}
