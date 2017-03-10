using System;
using System.Reflection;
using System.Linq;
using System.Diagnostics;

namespace MojaPasieka.DataModel
{
	[AttributeUsage(AttributeTargets.Field)]
	public class EnumNameAttribute : Attribute
	{
		public string name { get; private set;}

		public EnumNameAttribute(string name)
		{
			this.name = name;
		}

		/// <summary>
		/// Pobranie wartości atrybutu
		/// </summary>
		/// <returns>The value.</returns>
		/// <param name="enumValue">Enum value.</param>
		/// <typeparam name="TEnum">The 1st type parameter.</typeparam>
		public static string GetValue<TEnum>(TEnum enumValue) where TEnum : struct
		{
			var type = typeof(TEnum).GetTypeInfo();
			var members = type.DeclaredMembers;
			foreach (var member in members)
			{
				if (member.Name == enumValue.ToString())
				{
					var attr = member.GetCustomAttribute(typeof(EnumNameAttribute));
					if (attr != null)
					{
						return (attr as EnumNameAttribute).name;
					}
				}
			}
			return "";
		}
	}
}
