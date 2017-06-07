using Mustache;
using Nustache.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
                return new string[] { };
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


        [Route("nustache")]
        public HttpResponseMessage GetNustachePage()
        {
            string templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "article.html");

            using (StreamReader reader = new StreamReader(templatePath))
            {
                string strTemp = reader.ReadToEnd();

                var data = Template.Create();
                string result = Render.StringToString(strTemp, data);

                var response = new HttpResponseMessage();
                response.Content = new StringContent(result);
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");

                return response;
            }
        }

        [Route("mustache-sharp")]
        public HttpResponseMessage GetMustacheSharpPage()
        {
            string templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "article2.html");

            using (StreamReader reader = new StreamReader(templatePath))
            {
                string strTemp = reader.ReadToEnd();

                var data = Template.Create();

                FormatCompiler compiler = new FormatCompiler();
                Generator generator = compiler.Compile(strTemp);
                string result = generator.Render(data);

                var response = new HttpResponseMessage();
                response.Content = new StringContent(result);
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");

                return response;
            }
        }

        public class Template
        {
            public string Title { get; set; }
            public string Breadcrumbs { get; set; }
            public string Body { get; set; }
            public bool IfAllowFeedback { get; set; }
            public int HelfulPercent { get; set; }
            public List<Item> Items { get; set; }
            public Complex Comp { get; set; }

            public static Template Create()
            {
                return new Template
                {
                    Title = "Test mustache",
                    Breadcrumbs = "Test",
                    Body = "Thisi is a test for mustche",
                    IfAllowFeedback = true,
                    HelfulPercent = 58,
                    Items = new List<Item> {
                        new Item { Name="test1"},
                        new Item { Name="test2"}
                    },
                    Comp = new Complex
                    {
                        Child = new Child { Name = "Test Complex Type" }
                    }
                };
            }
        }

        public class Item
        {
            public string Name { get; set; }
        }

        public class Complex
        {
            public Child Child { get; set; }
        }
        public class Child
        {
            public string Name { get; set; }
        }
    }
}
