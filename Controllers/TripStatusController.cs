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
                jsonString = "{ \"success\": { \"id\": " + tripID.tripID.ToString() + "  } }";
            }
            catch (Exception e)
            {
                jsonString = "{ \"error\": { \"code\": 3, \"message\": \"can't accept trip\"  } }";
            }
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
        }

        // PUT api/tripstatus/5
        public HttpResponseMessage Put(int tripID, [FromBody] JObject steps)
        {
            string jsonString = string.Empty;
            try
            {
                //end the trip and change the status to ended
                clsTripRequest trip = new clsTripRequest();
                clsUser u = new clsUser();
                
                TripRequest userTrip = trip.get(tripID);

                decimal duration = 0M;
                decimal distance = 0M;
                decimal waitTime = 0M;
                decimal.TryParse(steps.GetValue("duration").ToString(), out duration);
                decimal.TryParse(steps.GetValue("distance").ToString(), out distance);
                if(distance != 0)
                {
                    waitTime = new clsTripRequest().calcWaitTime(distance, duration);
                }
                decimal finalCost = Math.Round(trip.calcCost(distance, waitTime, userTrip.CarCategory),3);
                
                trip.End(tripID,waitTime,distance, finalCost,steps.ToString());
                //notify the user with the end trip
                //get customer Device Token
                string customerDeviceToken = u.getUserDeviceToken(userTrip.UserID);


                //send notification to the user with the driver information
                AndroidGcmPushNotification not = new AndroidGcmPushNotification();
                //string jsonString = string.Empty;
                jsonString = "{ \"TripEnded\": { \"id\": " + tripID.ToString() + ",\"Cost\":\""+finalCost.ToString()+" LE\"  } }";
                //not.SendGcmNotification("", new string[] { customerDeviceToken }, jsonString);
                not.SendNotification("AAAA0-XrarI:APA91bEReLIPg2bjfuuPshOiO3GbDeFg7irdrAMF3h2ErPhsf2LOOEGLP4C0Hz2CKjzWspoK0V7JwLRTXs1Kz-fQikKZG2hZNikWrAxJK1gLueNJ9SuB5JU_3aF_b-dAtiTHrEzXA7fB-Z59suJsTBvI3DODJwpusA", "910095510194", customerDeviceToken, JsonConvert.SerializeObject(trip), "Trip Ended");
               // not.SendNotification("AIzaSyAUzTKuzVyD4ERLmaQb49bt4HnwioeVgT8", "UMove", customerDeviceToken, jsonString);
                ////////////////////////////////////////////////
                //    string s="[{\"distance\":{\"text\":\"10Km\",\"value\":1000.0},\"duration\":{\"text\":\"10 min\",\"value\":600000.0},\"end_location\":{\"lat\":25.22145,\"lng\":630.254},\"html_instructions\":\"Continue onto <b>Al Betrool</b>\",\"start_location\":{\"lat\":68.215,\"lng\":36.25412},\"travel_mode\":\"DRIVING\"}],\"Duration\":50.0}]"   ;
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
