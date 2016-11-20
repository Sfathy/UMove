using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UMoveNew.Controllers.AppCode;

namespace UMoveNew.Controllers
{
    public class TripStatusController : ApiController
    {
        // GET api/tripstatus
       /* public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/tripstatus/5
        public string Get(int id)
        {
            return "value";
        }*/

        // POST api/tripstatus
        public HttpResponseMessage Post(int tripID)
        {
            string jsonString = string.Empty;
            try
            {
                //start the trip and change the status to started
                clsTripRequest trip = new clsTripRequest();
                trip.Start(tripID);
                jsonString = "{ \"success\": { \"id\": " + tripID.ToString() + "  } }";
            }
            catch(Exception e)
            {
                jsonString = "{ \"error\": { \"code\": 3, \"message\": \"can't accept trip\"  } }";
            }
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
        }

        // PUT api/tripstatus/5
        public HttpResponseMessage Put(int tripID, decimal waitingTime, decimal distance, decimal cost)
        {
            string jsonString = string.Empty;
            try
            {
                //end the trip and change the status to ended
                clsTripRequest trip = new clsTripRequest();
                trip.End(tripID, waitingTime, distance, cost);
                jsonString = "{ \"success\": { \"id\": " + tripID.ToString() + "  } }";
            }
            catch (Exception e)
            {
                jsonString = "{ \"error\": { \"code\": 3, \"message\": \"can't accept trip\"  } }";
            }
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
        }

        // DELETE api/tripstatus/5
       /* public void Delete(int id)
        {
        }*/
    }
}
