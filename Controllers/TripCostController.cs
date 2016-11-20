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
    public class TripCostController : ApiController
    {
        // GET api/tripcost
        public HttpResponseMessage Get(decimal distance, decimal waitTime,int carCategory)
        {
            clsTripRequest trip = new clsTripRequest();
            decimal cost = trip.calcCost(distance, waitTime,carCategory);
            string jsonString = "{ \"cost\": { \"cost\": "+cost.ToString()+"  } }";
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };

            
        }

        // GET api/tripcost/5
      /*  public string Get(int id)
        {
            return "value";
        }

        // POST api/tripcost
        public void Post([FromBody]string value)
        {
        }

        // PUT api/tripcost/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/tripcost/5
        public void Delete(int id)
        {
        }*/
    }
}
