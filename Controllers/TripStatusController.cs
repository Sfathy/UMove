using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
            catch(Exception e)
            {
                jsonString = "{ \"error\": { \"code\": 3, \"message\": \"can't accept trip\"  } }";
            }
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
        }

        // PUT api/tripstatus/5
        public HttpResponseMessage Put(int tripID,List<TripRouteSteps> steps)
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
                //get customer Device Token
                string customerDeviceToken = u.getUserDeviceToken(userTrip.CustomerID);


                //send notification to the user with the driver information
                AndroidGcmPushNotification not = new AndroidGcmPushNotification();
                //string jsonString = string.Empty;
                jsonString = "{ \"Trip Ended\": { \"id\": " + tripID.ToString() + "  } }";
                //not.SendGcmNotification("", new string[] { customerDeviceToken }, jsonString);
                not.SendNotification("AIzaSyAUzTKuzVyD4ERLmaQb49bt4HnwioeVgT8", "UMove", customerDeviceToken, jsonString);
                ////////////////////////////////////////////////
                
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
