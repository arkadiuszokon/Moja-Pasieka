using System;
using System.Reflection;
using System.Linq;

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
			var member = type.DeclaredMembers.Where((MemberInfo arg) => arg.Name == nameof(enumValue)).First();
			var attr = member.GetCustomAttributes(typeof(EnumNameAttribute)).FirstOrDefault();
			if (attr == null)
			{
				return "";
			}
			return (attr as EnumNameAttribute).name;
		}
	}
}
