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
    public class FavDriverController : ApiController
    {
        // GET api/favdriver
        public HttpResponseMessage Get()
        {
            string jsonString = "";

            jsonString = JsonConvert.SerializeObject("");
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
        }

        // GET api/favdriver/5
        public HttpResponseMessage Get(int userId)
        {

            List<FavDriver> drivers = new List<FavDriver>();
            FavDriver d1 = new FavDriver();
            d1.UserID = 2;
            d1.DriverID = 4;
            d1.CarDescription = "Hundai Elintra Black";
            d1.CarNo = "ت ع 256";
            d1.Distance = 30;
            d1.DriverName = "Ahmed Hussien";
            d1.Duration = 120;
            d1.ID = 1;
            drivers.Add(d1);
            d1 = new FavDriver();
            d1.UserID = 2;
            d1.DriverID = 5;
            d1.CarDescription = "Hundai Elintra Black";
            d1.CarNo = "ت ع 256";
            d1.Distance = 50;
            d1.DriverName = "Adam Ali";
            d1.Duration = 180;
            d1.ID = 2;
            drivers.Add(d1);

            string jsonString = "";
            //DataTable dt = new clsTripRequest().get(userId, userType);
            jsonString = JsonConvert.SerializeObject(drivers);
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };

            
        }

        // POST api/favdriver
        public HttpResponseMessage Post([FromBody]FavDriver driver)
        {
            string jsonString = "{ \"success\": { \"id\": 3  } }"; ;
            
           // jsonString = JsonConvert.SerializeObject("");
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
        }

        // PUT api/favdriver/5
        public HttpResponseMessage Put(int id, [FromBody]FavDriver driver)
        {
            string jsonString = "{ \"success\": { \"id\": "+id.ToString()+"  } }"; ;
            
            
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
        }

        // DELETE api/favdriver/5
        public HttpResponseMessage Delete(int id)
        {
            string jsonString = "{ \"success\": { \"id\": " + id.ToString() + "  } }"; ;


            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
        }
    }
}
