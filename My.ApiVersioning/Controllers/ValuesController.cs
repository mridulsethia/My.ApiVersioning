using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;

namespace My.ApiVersioning.Controllers
{
	[Route("api/[controller]")]
    public class ValuesController : Controller
    {
		private readonly Dto.AppSettings m_appSettings;
		public ValuesController(IOptions<Dto.AppSettings> settingsAccessor)
		{
			m_appSettings = settingsAccessor.Value;
		}
		
		// GET api/values
		[HttpGet]
        public Models.ResponseModel Get()
        {
			HttpContext.Request.Query.TryGetValue("v", out Microsoft.Extensions.Primitives.StringValues ver);
			return Factories.DataFactory.Get(m_appSettings, ver.ToString());
        }

		// GET api/values/5
		[HttpGet("{id}")]
        public string Get(int id)
        {
            return "value: " + id;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
			throw new Exception("Not implemented");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
			throw new Exception("Not implemented");
		}

		// DELETE api/values/5
		[HttpDelete("{id}")]
        public void Delete(int id)
        {
			throw new Exception("Not implemented");
		}
	}
}
