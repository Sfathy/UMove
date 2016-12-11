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
                trip.End(tripID, 10, 50, 30);
                //notify the user with the end trip
                TripRequest userTrip = trip.get(tripID);
                decimal finalCost = trip.calcCost(userTrip.Distance, userTrip.WaitingTime, userTrip.CarCategory);
                //get customer Device Token
                string customerDeviceToken = u.getUserDeviceToken(userTrip.CustomerID);


                //send notification to the user with the driver information
                AndroidGcmPushNotification not = new AndroidGcmPushNotification();
                //string jsonString = string.Empty;
                jsonString = "{ \"Trip Ended\": { \"id\": " + tripID.ToString() + ",\"Cost\":"+finalCost.ToString()+"  } }";
                //not.SendGcmNotification("", new string[] { customerDeviceToken }, jsonString);
                not.SendNotification("AIzaSyAUzTKuzVyD4ERLmaQb49bt4HnwioeVgT8", "UMove", customerDeviceToken, jsonString);
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
