using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.IO;
using System.Collections.Specialized;
using System.Text;

namespace FormDataTesting.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "Hellow word";
        }

        // POST api/values
        //public void Post([FromBody]string value)
        public IEnumerable<string> Post([FromBody]string value)
        {
            var qs = "userID%5b0%5d=16555&gameID=60&score=4542.122&time=343114";
            var parsed = HttpUtility.ParseQueryString(qs);
            //var userId = parsed["test%5b0%5d"];

            //先以&切割
            //var queryString = qs.Split('&');
            //Console.WriteLine(qs);
            StringBuilder builder = new StringBuilder();
            foreach (var item in parsed)
            {
                var key = item.ToString();
                var tmpArr = key.Split(new string[] { "%5b" }, StringSplitOptions.RemoveEmptyEntries)[0];

                builder.Append(tmpArr);
                builder.Append(',');
                //Console.WriteLine(item.ToString());
            }
            //StringWriter myWriter = new StringWriter();
            //HttpUtility.HtmlDecode(value, myWriter);
            //Console.Write("Decoded string of the above encoded string is " + value);
            //Console.ReadLine();
            return new string[] { value };

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
