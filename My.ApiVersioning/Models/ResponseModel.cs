namespace My.ApiVersioning.Models
{
	public class ResponseModel
    {
		public enum Status {
			CurrentVersion = 200,	// Current version
			VersionFound = 210,		// This release is supported for a limited period, check the latest release notes and make necessary changes 
			ExpiryAlert = 220,		// This release is about to expire, make necessary changes before its too late 
			NotSupported = 230		// Asked version is not supported anymore!
		};

		public ResponseModel()
		{
			Message = string.Empty;
			StatusCode = (int) Status.CurrentVersion;
		}
		
		public int StatusCode { get; set; }
		public string Message { get; set; }
		public object Data { get; set; }
    }
}
