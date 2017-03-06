using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MojaPasieka.DataModel;

namespace MojaPasieka.Utils
{
	public class EnumHelper
	{
		
		public static IEnumerable<EnumDictionaryObject> ReturnListFromEnum<T>()
		{
			List<EnumDictionaryObject> dict = new List<EnumDictionaryObject>();
			TypeInfo type = typeof(T).GetTypeInfo();

			foreach (object enumValue in Enum.GetValues(typeof(T)))
			{
				var member = type.DeclaredMembers.Where((MemberInfo arg) => arg.Name == enumValue.ToString()).FirstOrDefault();
				var attr = member.GetCustomAttributes(typeof(EnumNameAttribute)).FirstOrDefault();
				dict.Add(new EnumDictionaryObject
				{
					Id = (int)enumValue,
					Description = enumValue.ToString(),
					Name = (attr as EnumNameAttribute).name
				});
			}

			return dict;

		}
	}

	public class EnumDictionaryObject : DataModelBase
	{
		private int _id;

		public int Id
		{
			get
			{
				return _id;
			}
			set
			{
				_id = value;
				OnPropertyChanged(nameof(Id));
			}
		}

		private string _desc;

		public string Description
		{
			get
			{
				return _desc;
			}
			set
			{
				_desc = value;
				OnPropertyChanged(nameof(Description));
			}
		}

		private string _name;

		public string Name
		{ 
			get
			{
				return _name;
			}
			set
			{
				_name = value;
				OnPropertyChanged(nameof(Name));
			}
		}
	}
}
