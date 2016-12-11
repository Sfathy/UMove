using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
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
          JObject  routs = (JObject)JsonConvert.DeserializeObject(t.Route, typeof(JObject));
          routs.Add("ID", id);
          routs.Add("UserID", t.UserID);
          routs.Add("SourceLat", t.SourceLat);
          routs.Add("Sourcelong", t.Sourcelong);
          routs.Add("DestLat", t.DestLat);
          routs.Add("DestLong", t.DestLong);
          routs.Add("DriverID", t.DriverID);
            //get driver info this isn't real data 
          routs.Add("DriverID", "Hossam");
          routs.Add("DriverLat", "30.151425467127243");
          routs.Add("DriverLat", "31.321661397814747");
          routs.Add("PicUpDate", t.PicUpDate);
          routs.Add("Status", t.Status);
          routs.Add("PaymentMethod", t.PaymentMethod);
          routs.Add("CarCategory", t.CarCategory);
          routs.Add("Distance", t.Distance);
          routs.Add("WaitingTime", t.WaitingTime);
          routs.Add("Cost", t.Cost);
          string s = JsonConvert.SerializeObject(routs);
            string jsonString =JsonConvert.SerializeObject(t);
           // return t;
              return new HttpResponseMessage() { Content = new StringContent(s.Trim(), System.Text.Encoding.UTF8, "application/jason") };

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
