using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UMoveNew.Controllers
{
    public class BalanceController : ApiController
    {
        // GET api/balance
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/balance/5
        public HttpResponseMessage Get(int userId,int userType)
        {
            string jsonString = "";
            if(userType==0) //user
                jsonString = "{ \"UserBalance\": { \"Point\": 60 , \"Km\":120 , \"Money\":\"20 L.E\"} }";
            else //driver
                jsonString = "{ \"UserBalance\": {  \"Km\":120 , \"Money\":\"20 L.E\"} }";
            // DataTable dt = new clsTripRequest().get(userId, userType);

            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
        }

        // POST api/balance
        public void Post([FromBody]string value)
        {
        }

        // PUT api/balance/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/balance/5
        public void Delete(int id)
        {
        }
    }
}
