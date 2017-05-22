using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web;
using System.Web.Http;

namespace KB.WebApi.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            var test = HttpContext.Current.Session["test"];
            if (test == null)
            {
                HttpContext.Current.Session["test"] = "test";
                return new string[] {};
            }
            else
            {
                return new string[] { HttpContext.Current.Session["test"].ToString() };
            }
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public string Post([FromBody]string value)
        {
            HttpContext.Current.Session["test"] = "aaaaa";
            return HttpContext.Current.Session["test"].ToString();
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
