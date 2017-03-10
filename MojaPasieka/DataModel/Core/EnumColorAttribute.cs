using System;
using System.Reflection;
using System.Linq;
namespace MojaPasieka
{
	[AttributeUsage(AttributeTargets.Field)]
	public class EnumColorAttribute : Attribute
	{
		public string hexString { get; private set; }

		public EnumColorAttribute(string hexString)
		{
			this.hexString = hexString;
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
			var member = type.DeclaredMembers.Where((MemberInfo arg) => arg.Name == enumValue.ToString()).FirstOrDefault();
			var attr = member.GetCustomAttributes(typeof(EnumColorAttribute)).FirstOrDefault();
			if (attr == null)
			{
				return "";
			}
			return (attr as EnumColorAttribute).hexString;
		}
	}
}
