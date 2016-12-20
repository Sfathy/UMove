using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UMoveNew.Controllers
{
    public class VerfiyNoController : ApiController
    {
        // GET api/verfiyno
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/verfiyno/5
        public HttpResponseMessage Get(int code, int userID)
        {
            string jsonString = "{ \"success\": { \"id\":3 } }";
            // DataTable dt = new clsTripRequest().get(userId, userType);

            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
        }

        // POST api/verfiyno
        public void Post([FromBody]string value)
        {
        }

        // PUT api/verfiyno/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/verfiyno/5
        public void Delete(int id)
        {
        }
    }
}
