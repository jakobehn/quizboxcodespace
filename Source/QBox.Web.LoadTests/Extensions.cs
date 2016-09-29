using System;
using System.ComponentModel;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.WebTesting;
using Newtonsoft.Json.Linq;

namespace QBox.Web.LoadTests
{

        [DisplayName("JSON Extraction Rule")]
        [Description("Extracts the specified JSON value from an object.")]
        public class JsonExtractionRule : ExtractionRule
        {
            public string Name { get; set; }

            public override void Extract(object sender, ExtractionEventArgs e)
            {
                if (e.Response.BodyString != null)
                {
                    var json = e.Response.BodyString;
                    var data = JArray.Parse(json);

                    if (data != null)
                    {
                        e.WebTest.Context.Add(this.ContextParameterName, data.SelectToken(Name));
                        e.Success = true;
                        return;
                    }
                }

                e.Success = false;
                e.Message = String.Format(CultureInfo.CurrentCulture, "Not Found: {0}", Name);
            }
        }
}
