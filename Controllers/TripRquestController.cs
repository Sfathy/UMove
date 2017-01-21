using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
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
                DataRow dr;
                dt.Columns.Add("duration");
                dt.Columns.Add("driverDescription");
                dt.Columns.Add("NumberOfTrips");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string sql = "SELECT COUNT(*) AS NumberOfTrips FROM dbo.TripRequest WHERE (UserID = "+dt.Rows[i]["UserID"].ToString()+") AND (Status = 1 OR Status = 2 OR Status = 4)";
                    DataTable dtNumberOfTrips = DataAccess.ExecuteSQLQuery(sql);
                   // dr = dt.NewRow();
                    dt.Rows[i]["duration"] = ((clsUserLocation.dist)loc.getDistance(Latitude, Longitude, decimal.Parse(dt.Rows[i]["latitude"].ToString()), decimal.Parse(dt.Rows[i]["Longitude"].ToString()))).duration;
                    dt.Rows[i]["driverDescription"] = dt.Rows[i]["Name"];
                    dt.Rows[i]["NumberOfTrips"] = dtNumberOfTrips.Rows[0]["NumberOfTrips"];
                }
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
                    trip.PicUpDate = DateTime.UtcNow;
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
                    not.SendNotification("AAAA0-XrarI:APA91bEReLIPg2bjfuuPshOiO3GbDeFg7irdrAMF3h2ErPhsf2LOOEGLP4C0Hz2CKjzWspoK0V7JwLRTXs1Kz-fQikKZG2hZNikWrAxJK1gLueNJ9SuB5JU_3aF_b-dAtiTHrEzXA7fB-Z59suJsTBvI3DODJwpusA", "910095510194", dt.Rows[i]["deviceToken"].ToString(), JsonConvert.SerializeObject(trip), "New Trip Requested");

                    //not.SendNotification("AIzaSyAUzTKuzVyD4ERLmaQb49bt4HnwioeVgT8", "", dt.Rows[i]["deviceToken"].ToString(), JsonConvert.SerializeObject(trip));
                }
                //string url = "https://maps.googleapis.com/maps/api/directions/json?origin="+trip.SourceLat.ToString()+"%2C"+trip.Sourcelong.ToString()+"&destination="+trip.DestLat.ToString()+"%2C"+trip.DestLong.ToString();
                //HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(string.Format(url));
                //webReq.Method = "GET";
                //HttpWebResponse webResponse = (HttpWebResponse)webReq.GetResponse();
                //using (Stream responseStream = webResponse.GetResponseStream())
                //{
                //    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                //    jsonString =  reader.ReadToEnd();
                //}
             //   TripRoute t = (TripRoute)Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString, typeof(TripRoute));

                jsonString = "{ \"success\": { \"id\": " + tripID.ToString() + "  } }";
                //return webResponse;
            }
            catch (Exception e)
            {
                jsonString = "{ \"error\": { \"code\": 3, \"message\": \"can't save trip\"  } }";
            }
            return  new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
        }

        // PUT api/triprquest/5
        /*   public void Put(int id, [FromBody]string value)
           {
           }
*/
           // DELETE api/triprquest/5
           public HttpResponseMessage Delete(int id,int userType)
           {
               clsTripRequest tripRq = new clsTripRequest();
               tripRq.cancelTrip(id,userType);
               string jsonString = "{ \"success\": { \"id\": " + id.ToString() + "  } }";
               return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
           }
    }
}
