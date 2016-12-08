using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

namespace UMoveNew.Controllers
{
    public class TripCostController : ApiController
    {
        // GET api/tripcost
        public HttpResponseMessage Get(decimal sourceLat,decimal sourceLng,decimal destinationLat,decimal destinationLng, int carCategory)
        {

            string url = "https://maps.googleapis.com/maps/api/directions/json?origin=" + sourceLat.ToString() + "%2C" + sourceLng.ToString() + "&destination=" + destinationLat.ToString() + "%2C" + destinationLng.ToString() + "&alternatives=true";
            string jsonString = string.Empty;
            HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(string.Format(url));
            webReq.Method = "GET";
            HttpWebResponse webResponse = (HttpWebResponse)webReq.GetResponse();
            using (Stream responseStream = webResponse.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }
            JObject googleApi = (JObject)JsonConvert.DeserializeObject(jsonString, typeof(JObject));
            JArray routes = (JArray)googleApi["routes"];
            decimal distance = 0;
            decimal waitTime = 30;
            clsTripRequest trip = new clsTripRequest();
            decimal cost = 0 ; //= trip.calcCost(distance, waitTime, carCategory);
            JObject j = null;
            for (int i = 0; i < routes.Count; i++)
            {
                distance = Convert.ToDecimal(routes[i]["legs"][0]["distance"]["value"].ToString())/1000;
                waitTime = Convert.ToDecimal(routes[i]["legs"][0]["duration"]["value"].ToString());
                waitTime = waitTime / 60;
                waitTime = waitTime - (40 / distance * 60);
                if (waitTime < 0)
                    waitTime = 0;
                cost = trip.calcCost(distance, waitTime, carCategory);
                
                j = (JObject) routes[i];
                j.Add("cost", cost.ToString());
                routes[i] = j;
            }
            


            
           
             //jsonString = "{ \"cost\": { \"cost\": "+cost.ToString()+",\"time\":"+waitTime.ToString()+"  } }";
            return new HttpResponseMessage() { Content = new StringContent(routes.ToString(), System.Text.Encoding.UTF8, "application/jason") };

            
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
