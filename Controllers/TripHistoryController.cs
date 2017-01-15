using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UMoveNew.Controllers.AppCode;

namespace UMoveNew.Controllers
{
    public class TripHistoryController : ApiController
    {
        // GET api/triphistory
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/triphistory/5
        public HttpResponseMessage Get(int userId, int userType, int isFuture,int pageNo)
        {
            string jsonString = "";
            DataTable dt = new clsTripRequest().get(userId, userType,isFuture);
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                jsonString = JsonConvert.SerializeObject(dt);
            }
            else
            {
                jsonString = "{ \"error\": { \"code\": 3, \"message\": \"can't find trips for this user \"  } }"; ;
            }
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
        }

        // POST api/triphistory
        public void Post([FromBody]string value)
        {
        }

        // PUT api/triphistory/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/triphistory/5
        public void Delete(int id)
        {
        }
    }
}
