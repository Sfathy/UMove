using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using UMoveNew.Controllers.AppCode;
using UMoveNew.Models;

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
        public class TripModel
        {
            public int tripID { get; set; }
        }
        // POST api/tripstatus
        public HttpResponseMessage Post([FromBody]TripModel  tripID)
        {
            string jsonString = string.Empty;
            try
            {
                
                //start the trip and change the status to started
                clsTripRequest trip = new clsTripRequest();
                trip.Start(tripID.tripID);
                TripRequest userTrip = trip.get(tripID.tripID);
                string customerDeviceToken = new clsUser().getUserDeviceToken(userTrip.UserID);

                var message = new
                {
                    to = customerDeviceToken,
                    notification = new
                    {
                        title = "Your Trip Started",
                        body = "Your trip started " ,
                        status = "Started",
                        id = tripID.tripID.ToString()
                    }
                };
                //send notification to the user with the driver information
                AndroidGcmPushNotification not = new AndroidGcmPushNotification();
                //string jsonString = "{ \"TripAccepted\": { \"id\": " + acceptTrip.RequestID.ToString() + " ,\"DriverName\":\""+dtDriver.Rows[0]["Name"].ToString()+"\" } }";
               //jsonString = "{ \"TripStarted\": {\"Status\":\"Started\", \"id\": " + tripID.tripID.ToString() + "  } }";
                //jsonString = JsonConvert.SerializeObject(dtDriver);
                //not.SendGcmNotification("", new string[] { customerDeviceToken }, jsonString);
                not.SendNotification("AAAA0-XrarI:APA91bEReLIPg2bjfuuPshOiO3GbDeFg7irdrAMF3h2ErPhsf2LOOEGLP4C0Hz2CKjzWspoK0V7JwLRTXs1Kz-fQikKZG2hZNikWrAxJK1gLueNJ9SuB5JU_3aF_b-dAtiTHrEzXA7fB-Z59suJsTBvI3DODJwpusA", "910095510194", customerDeviceToken, message, "Trip Accepted");
                jsonString = "{ \"success\": { \"id\": " + tripID.tripID.ToString() + "  } }";
            }
            catch (Exception e)
            {
                jsonString = "{ \"error\": { \"code\": 3, \"message\": \"can't accept trip\"  } }";
            }
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json") };
        }

        // PUT api/tripstatus/5
        public HttpResponseMessage Put(int tripID, [FromBody] EndedTripInfo  endedTripInfo)
        {
            string jsonString = string.Empty;
            try
            {
                //end the trip and change the status to ended
                clsTripRequest trip = new clsTripRequest();
                decimal cost =  trip.End(tripID,endedTripInfo);
                jsonString = " { \"tripID\": "+tripID.ToString()+",\"Cost\":"+cost.ToString()+"   }";
            }
            catch (Exception e)
            {
                jsonString = "{ \"error\": { \"code\": 3, \"message\": \"can't end trip\"  } }";
            }
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json") };
        }

        // DELETE api/tripstatus/5
        /* public void Delete(int id)
         {
         }*/
    }
}
