namespace My.ApiVersioning.Models
{
	public class ResponseModel
    {
		public enum Status {
			Ok = 200,			// Bleeding edge, the structure of this version is subject to continuous updates.
			ExpiryAlert = 301,	// This release is about to expire, make necessary changes before its too late 
			NotFound = 404		// Asked version is not supported anymore!
		};

		public ResponseModel()
		{
			Message = string.Empty;
			StatusCode = (int) Status.Ok;
		}
		
		public int StatusCode { get; set; }
		public string Message { get; set; }
		public object Data { get; set; }
    }
}
