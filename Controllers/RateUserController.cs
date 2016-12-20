using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UMoveNew.Models;

namespace UMoveNew.Controllers
{
    public class RateUserController : ApiController
    {
        // GET api/rateuser
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/rateuser/5
        public HttpResponseMessage Get(int userId)
        {
            List<RateDriver> drivers = new List<RateDriver>();
            RateDriver d1 = new RateDriver();
            d1.UserID = userId;
            //d1.DriverID = userId;
            d1.Feedback = "Good Driver";
            d1.Name = "Adam Ali";
            d1.Rate = 4;
            //d1.TripID = 5;
            d1.ID = 1;
            drivers.Add(d1);
            /*d1 = new RateDriver();
            d1.UserID = 3;
            d1.DriverID = driverId;
            d1.DriverName = "Adam Ali";
            d1.Feedback = "Good Driver";
            d1.Rate = 3;
            d1.TripID = 6;
            d1.ID = 2;
            drivers.Add(d1); */

            string jsonString = "";
            //DataTable dt = new clsTripRequest().get(userId, userType);
            jsonString = JsonConvert.SerializeObject(drivers);
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };

        }

        // POST api/ratedriver
        public HttpResponseMessage Post([FromBody]RateDriver Rate)
        {
            string jsonString = "{ \"success\": { \"id\": 3  } }"; ;

            // jsonString = JsonConvert.SerializeObject("");
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
        }
        // PUT api/rateuser/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/rateuser/5
        public void Delete(int id)
        {
        }
    }
}
