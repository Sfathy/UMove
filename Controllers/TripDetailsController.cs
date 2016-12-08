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
    public class TripDetailsController : ApiController
    {
        // GET api/tripdetails
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/tripdetails/5
        public HttpResponseMessage Get(int id)
        {
            
            clsTripRequest trip = new clsTripRequest();
            TripRequest t = trip.get(id);
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

           
            //return webResponse;

            string jsonString = JsonConvert.SerializeObject(t);
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };

        }

        // POST api/tripdetails
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/tripdetails/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/tripdetails/5
        //public void Delete(int id)
        //{
        //}
    }
}
