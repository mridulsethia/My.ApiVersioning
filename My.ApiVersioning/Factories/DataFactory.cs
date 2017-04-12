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
			// return latest model if no specific version requested
			if (string.IsNullOrEmpty(ver))
			{
				res.Data = new Models.ValueModel().Values;
				return res;
			}
			// if requested version is not configured or expired, return empty data object with correct status
			var supportedVer = appSettings.SupportedVersionList.Find(i => i.Number.Equals(ver));
			if (null == supportedVer || DateTime.Today > supportedVer.ExpiryDateTime)
			{
				res.StatusCode = (int)Models.ResponseModel.Status.NotSupported;
				res.Message = "End of the road! Version you are asking is long gone!";
				return res;
			}
			// set correct status-code and message in the response.
			if (DateTime.Today < supportedVer.ExpiryAlertDateTime)
			{
				res.StatusCode = (int)Models.ResponseModel.Status.VersionFound;
				res.Message = "Compatibility Alert! This version expires on 31 Dec. Check latest release notes to update.";
			}
			else
			{
				res.StatusCode = (int)Models.ResponseModel.Status.ExpiryAlert;
				res.Message = "Expiry Alert! You've ignored this long enough! It's time to update.";
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
