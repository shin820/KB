using DotLiquid;
using DynamicExpresso;
using HandlebarsDotNet;
using Mustache;
using Nustache.Core;
using System;
using System.Collections;
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

                var data = TemplateData.Create();
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

                var data = TemplateData.Create();

                FormatCompiler compiler = new FormatCompiler();
                compiler.RegisterTag(new ListTagDefinition<Item>(), true);
                Generator generator = compiler.Compile(strTemp);
                string result = generator.Render(data);

                var response = new HttpResponseMessage();
                response.Content = new StringContent(result);
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");

                return response;
            }
        }

        [Route("handlebars")]
        public HttpResponseMessage GetHandlebarsPage()
        {
            string templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "article2.html");

            using (StreamReader reader = new StreamReader(templatePath))
            {
                string strTemp = reader.ReadToEnd();

                var data = TemplateData.Create();
                RegisterHelpers();
                var template = Handlebars.Compile(strTemp);
                string result = template(data);

                var response = new HttpResponseMessage();
                response.Content = new StringContent(result);
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");

                return response;
            }
        }

        private void RegisterHelpers()
        {
            Handlebars.RegisterHelper("#list", (writer, context, parameters) =>
            {
                var items = parameters[0] as IList<Item>;
                var limit = int.Parse(parameters[1].ToString());
                items = items.Take(5).ToList();
                foreach (var item in items)
                {
                    writer.WriteSafeString("<li>" + item.Name + "</li>");
                }
            });

            Handlebars.RegisterHelper("Compare", (writer, options, context, parameters) =>
            {
                if (parameters.Count() < 3)
                {
                    throw new InvalidOperationException("Handlerbars Helper 'Compare' needs 3 parameters");
                }

                string oprt = parameters[1].ToString();
                bool result = false;
                if (oprt == "==")
                {
                    result = parameters[0] == parameters[2];
                }
                if (oprt == "!=")
                {
                    result = parameters[0] != parameters[2];
                }
                if (oprt == ">")
                {
                    result = decimal.Parse(parameters[0].ToString()) > decimal.Parse(parameters[2].ToString());
                }
                if (oprt == "<")
                {
                    result = decimal.Parse(parameters[0].ToString()) < decimal.Parse(parameters[2].ToString());
                }
                if (oprt == ">=")
                {
                    result = decimal.Parse(parameters[0].ToString()) >= decimal.Parse(parameters[2].ToString());
                }
                if (oprt == "<=")
                {
                    result = decimal.Parse(parameters[0].ToString()) <= decimal.Parse(parameters[2].ToString());
                }
                if (oprt == "&&")
                {
                    result = bool.Parse(parameters[0].ToString()) && bool.Parse(parameters[2].ToString());
                }
                if (oprt == "||")
                {
                    result = bool.Parse(parameters[0].ToString()) || bool.Parse(parameters[2].ToString());
                }

                if (result)
                {
                    options.Template(writer, context);
                }
                else
                {
                    options.Inverse(writer, context);
                }
            });

            Handlebars.RegisterHelper("xif", (writer, options, context, parameters) =>
            {
                string expression = parameters[0].ToString();

                var interpreter = new Interpreter().SetVariable("x", context);
                var isTrue = interpreter.Eval<bool>(expression);

                if (isTrue)
                {
                    options.Template(writer, context);
                }
                else
                {
                    options.Inverse(writer, context);
                }
            });
        }

        [Route("liquid")]
        public HttpResponseMessage GetliquidPage()
        {
            string templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "article3.html");

            using (StreamReader reader = new StreamReader(templatePath))
            {
                string strTemp = reader.ReadToEnd();

                var data = TemplateData.Create();

                DotLiquid.Template template = DotLiquid.Template.Parse(strTemp);  // Parses and compiles the template
                string result = template.Render(Hash.FromAnonymousObject(data)); // Renders the output

                var response = new HttpResponseMessage();
                response.Content = new StringContent(result);
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");

                return response;
            }
        }

        public class ListTagDefinition<T> : ContentTagDefinition
        {
            private const string collectionParameter = "collection";
            private static readonly TagParameter collection = new TagParameter(collectionParameter) { IsRequired = true };
            private static readonly TagParameter limit = new TagParameter("limit") { IsRequired = false, DefaultValue = 3 };

            /// <summary>
            /// Initializes a new instance of an EachTagDefinition.
            /// </summary>
            public ListTagDefinition()
                : base("list")
            {
            }

            /// <summary>
            /// Gets whether the tag only exists within the scope of its parent.
            /// </summary>
            protected override bool GetIsContextSensitive()
            {
                return false;
            }

            /// <summary>
            /// Gets the parameters that can be passed to the tag.
            /// </summary>
            /// <returns>The parameters.</returns>
            protected override IEnumerable<TagParameter> GetParameters()
            {
                return new TagParameter[] { collection, limit };
            }

            /// <summary>
            /// Gets the context to use when building the inner text of the tag.
            /// </summary>
            /// <param name="writer">The text writer passed</param>
            /// <param name="keyScope">The current scope.</param>
            /// <param name="arguments">The arguments passed to the tag.</param>
            /// <returns>The scope to use when building the inner text of the tag.</returns>
            public override IEnumerable<NestedContext> GetChildContext(
                TextWriter writer,
                Scope keyScope,
                Dictionary<string, object> arguments,
                Scope contextScope)
            {
                object value = arguments[collectionParameter];
                int limit = int.Parse(arguments["limit"].ToString());
                IList<T> enumerable = value as IList<T>;
                if (enumerable == null)
                {
                    yield break;
                }

                enumerable = enumerable.Take(limit).ToList();

                int index = 0;
                foreach (object item in enumerable)
                {
                    NestedContext childContext = new NestedContext()
                    {
                        KeyScope = keyScope.CreateChildScope(item),
                        Writer = writer,
                        ContextScope = contextScope.CreateChildScope(),
                    };
                    //childContext.ContextScope.Set("index", index);
                    yield return childContext;
                    ++index;
                }
            }


            /// <summary>
            /// Gets the parameters that are used to create a new child context.
            /// </summary>
            /// <returns>The parameters that are used to create a new child context.</returns>
            public override IEnumerable<TagParameter> GetChildContextParameters()
            {
                return new TagParameter[] { collection, limit };
            }
        }

        public class TemplateData : Drop
        {
            public string Title { get; set; }
            public string Breadcrumbs { get; set; }
            public string Body { get; set; }
            public bool IfAllowFeedback { get; set; }
            public int HelfulPercent { get; set; }
            public List<Item> Items { get; set; }
            public Complex Comp { get; set; }

            public static TemplateData Create()
            {
                return new TemplateData
                {
                    Title = "Test mustache",
                    Breadcrumbs = "Test",
                    Body = "Thisi is a test",
                    IfAllowFeedback = true,
                    HelfulPercent = 58,
                    Items = new List<Item> {
                        new Item { Name="test1"},
                        new Item { Name="test2"},
                        new Item { Name="test3"},
                        new Item { Name="test4"},
                        new Item { Name="test5"},
                        new Item { Name="test6"},
                        new Item { Name="test7"},
                        new Item { Name="test8"},
                        new Item { Name="test9"},
                        new Item { Name="test10"}
                    },
                    Comp = new Complex
                    {
                        Child = new Child { Name = "Test Complex Type" }
                    }
                };
            }
        }

        public class Item : Drop
        {
            public string Name { get; set; }
        }

        public class Complex : Drop
        {
            public Child Child { get; set; }
        }
        public class Child : Drop
        {
            public string Name { get; set; }
        }
    }
}
