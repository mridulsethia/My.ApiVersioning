using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;

namespace My.ApiVersioning.Common
{
	public static class Helper
    {
		public static dynamic ToDynamic(object value)
		{
			IDictionary<string, object> expando = new ExpandoObject();

			foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(value.GetType()))
				expando.Add(property.Name, property.GetValue(value));

			return expando;
		}
		public static void RemoveProperty(ExpandoObject expando, string prop)
		{
			IDictionary<string, object> map = expando;
			map.Remove(prop);
		}
	}
}
