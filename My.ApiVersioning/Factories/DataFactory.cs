using System;

namespace My.ApiVersioning.Factories
{
	public static class DataFactory
    {
		/// <summary>
		/// Return appropriate version specific data model.
		/// </summary>
		public static Models.ResponseModel Get(Dto.AppSettings appSettings, string ver)
		{
			var res = new Models.ResponseModel();

			if (string.IsNullOrWhiteSpace(ver)) // return latest model if no specific version requested
			{
				res.Message = "You're on the bleeding edge in the world of continuous changes! Structure of this API is subject for running updates without any notifications!";
				res.Data = new Models.ValueModel().Values;
				return res;
			}

			// if requested version is not configured OR expired, return empty data object with appropriate status
			var supportedVer = appSettings.SupportedVersionList.Find(i => i.Number.Equals(ver));
			if (null == supportedVer || DateTime.Today > supportedVer.ExpiryDateTime.AddDays(1))
			{
				res.StatusCode = (int)Models.ResponseModel.Status.NotFound;
				res.Message = "End of the road! Version you are asking is long gone! To check the latest development, call the API without a specific version.";
				return res;
			}

			if (DateTime.Today > supportedVer.ExpiryAlertDateTime)
			{
				res.StatusCode = (int)Models.ResponseModel.Status.ExpiryAlert;
				res.Message = string.Format("Expiry Alert! This version expires on {0}. To check the latest development, call this API without a specific version.", supportedVer.ExpiryDateTime.ToString("yyyy-dd-MM"));
			}

			// add correct model to the response
			switch (supportedVer.Number)
			{
				//case "1":	// In this example, public v1 is already obselete. Commented code kept just as an example
					//res.Data = new Public.ValueModelV1().Values;
				case "2":
					res.Data = new Public.ValueModelV2().Values;
					break;
			}
			return res;
		}
	}
}
