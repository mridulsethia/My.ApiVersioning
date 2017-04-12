using System;
using System.Collections.Generic;

namespace My.ApiVersioning.Dto
{
	public class AppSettings
	{
		public List<SupportedVersion> SupportedVersionList { get; set; }
		public string ConnectionString { get; set; }
	}
	public class SupportedVersion
	{
		public string Number { get; set; }
		public string ExpiryAlertDate { get; set; }
		public string ExpiryDate { get; set; }
		public DateTime ExpiryAlertDateTime { get{ return Convert.ToDateTime(ExpiryAlertDate); } }
		public DateTime ExpiryDateTime { get { return Convert.ToDateTime(ExpiryDate); } }
	}
}
