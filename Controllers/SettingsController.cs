using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UMoveNew.Controllers
{
    public class SettingsController : ApiController
    {
        // GET api/settings
        public HttpResponseMessage Get()
        {
            string jsonString = "{ \"Settings\": { \"DriverTimer\": 30,\"DriverCancelFee\":7,\"UserCancelFee\":7,\"DateFormat\":MM/dd/yyyy HH:mm:ss  } }";
           // DataTable dt = new clsTripRequest().get(userId, userType);
            
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
        }

        // GET api/settings/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/settings
        public void Post([FromBody]string value)
        {
        }

        // PUT api/settings/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/settings/5
        public void Delete(int id)
        {
        }
    }
}
