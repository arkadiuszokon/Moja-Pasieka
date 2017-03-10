using System;
using MojaPasieka.DataModel;

namespace MojaPasieka.Utils
{
	public class QueenBeeHelper
	{
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
