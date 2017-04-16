using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UMoveNew.Controllers
{
    public class BecomeDriverController : ApiController
    {
        // GET api/becomedriver
        public HttpResponseMessage Get()
        {
            string jsonString = "{ \"URL\": { \"url\": http://umove2.mline-ksa1.com/ } }";
            // DataTable dt = new clsTripRequest().get(userId, userType);

            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json") };
        }

        // GET api/becomedriver/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/becomedriver
        public void Post([FromBody]string value)
        {
        }

        // PUT api/becomedriver/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/becomedriver/5
        public void Delete(int id)
        {
        }
    }
}
