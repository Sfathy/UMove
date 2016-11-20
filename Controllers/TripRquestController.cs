using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UMoveNew.Controllers.AppCode;
using UMoveNew.Models;

namespace UMoveNew.Controllers
{
    public class TripRequestController : ApiController
    {
        // GET api/triprquest
        public HttpResponseMessage Get(decimal Latitude, decimal Longitude, int UserID, string AccessToken)
        {
            clsUserLocation loc = new clsUserLocation();
            DataTable dt = loc.getNearestDrivers(Latitude, Longitude);
            string jsonString = string.Empty;
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                jsonString = JsonConvert.SerializeObject(dt);
            }
            else
            {
                jsonString = "{ \"error\": { \"code\": 3, \"message\": \"can't find drivers around your location\"  } }";
            }
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
        }

        // GET api/triprquest/5
        /*  public string Get(int id)
          {
              return "value";
          }*/

        // POST api/triprquest
        public HttpResponseMessage Post([FromBody]TripRequest trip)
        {
            string jsonString = string.Empty;
            try
            {
                //save the trip and get the trip ID
                clsTripRequest tripRequest = new clsTripRequest();
                if (trip.PicUpDate == DateTime.MinValue)
                {
                    trip.PicUpDate = DateTime.Today;
                }
                int tripID = tripRequest.insert(trip);
                trip.ID = tripID;
                //get the nearby drivers 
                clsUserLocation loc = new clsUserLocation();
                DataTable dt = loc.getNearestDrivers(trip.SourceLat, trip.Sourcelong);

                //send the notification to the drivers using the trip info
                AndroidGcmPushNotification not = new AndroidGcmPushNotification();
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    not.SendGcmNotification("", new string[] { dt.Rows[i]["deviceToken"].ToString() }, JsonConvert.SerializeObject(trip), "Customer Request");
                }
                jsonString = "{ \"success\": { \"id\": " + tripID.ToString() + "  } }";
            }
            catch (Exception e)
            {
                jsonString = "{ \"error\": { \"code\": 3, \"message\": \"can't save trip\"  } }";
            }
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
        }

        // PUT api/triprquest/5
        /*   public void Put(int id, [FromBody]string value)
           {
           }

           // DELETE api/triprquest/5
           public void Delete(int id)
           {
           }*/
    }
}
