using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
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

		public static string GetApiVersion(HttpRequest request)
		{
			StringValues ver;
			if (request.Query.ContainsKey("v")) // version requested via querystring overrides version requested via headers
			{
				request.Query.TryGetValue("v", out ver);
			}
			else
			{
				if (request.Headers.ContainsKey("api-version"))
				{
					ver = request.Headers["api-version"];
				}
			}
			return ver.ToString().Trim();
		}
	}
}
