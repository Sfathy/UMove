using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UMoveNew.Controllers
{
    public class HelpController : ApiController
    {
        // GET api/help
        public HttpResponseMessage Get()
        {
            string jsonString = "{ \"HelpURL\": { \"url\": http://umove2.mline-ksa1.com/ } }";
            // DataTable dt = new clsTripRequest().get(userId, userType);

            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
        }

        // GET api/help/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/help
        public void Post([FromBody]string value)
        {
        }

        // PUT api/help/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/help/5
        public void Delete(int id)
        {
        }
    }
}
