﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
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
          if (t.DriverID != 0)
          {
              RateDriver d1 = new clsUserRate().get(t.DriverID);
              //get driver info this isn't real data 
              routs.Add("DriverName", t.DriverName);
              routs.Add("DriverPhone", t.DriverPhone);
              routs.Add("DriverCarNo", t.DriverCarNo);
              routs.Add("DriverCarDescription", t.DriverCarDescription);
              // demo photo
              routs.Add("DriverPhoto", t.DriverPhoto);
              routs.Add("DriverRate", t.DriverRate);
              routs.Add("IsFav", t.IsFav);
              List<UserLocation> loc = new clsUserLocation().get(t.DriverID);
              if(loc != null && loc.Count >0)
              {
                  routs.Add("DriverLat", loc[0].Latitude);
                  routs.Add("DriverLng", loc[0].Longitude);
                  routs.Add("DriverAngle", loc[0].Angle);
              }
          }
          routs.Add("UserName", t.UserName);
          routs.Add("UserPhone", t.UserPhone);
            
          routs.Add("PicUpDate", t.PicUpDate);
          routs.Add("Status", t.Status);
          routs.Add("PaymentMethod", t.PaymentMethod);
          routs.Add("CarCategory", t.CarCategory);
          routs.Add("Distance", t.Distance);
          routs.Add("WaitingTime", t.WaitingTime);
          routs.Add("StartTime", t.StartTime);
          routs.Add("EndTime", t.EndTime);

          routs.Add("Cost", t.Cost.ToString()+" LE");

          routs.Add("EstimatedDistance", t.EstimatedDistance);
          routs.Add("EstimaedDuration", t.EstimatedDuration);
          routs.Add("EstimatedCost", t.EstimatedCost );
          routs.Add("StartAddress", t.StartAddress);
          routs.Add("EndAddress", t.EndAddress);
          routs.Add("NoOfSeats", t.NoOfSeats);
          routs.Add("Steps", t.Steps); 
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
