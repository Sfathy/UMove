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
            //use this URL to get the distance between user and driver
            //https://maps.googleapis.com/maps/api/distancematrix/json?units=imperial&origins=30.151425467127243%2C31.321661397814747&destinations=30.071246%2C31.3516287&key=AIzaSyBrnXeFYGzOaWAktnIISiPiQ4A49pZxsRc

            List<FavDriver> drivers = new clsFavDriver().get(userId);
            FavDriver d1 = new FavDriver();
            for (int i = 0; i < drivers.Count; i++)
            {
                d1 = new FavDriver();
                d1 = drivers[i];
                d1.CarDescription = "Hundai Elintra Black";
                d1.CarNo = "ت ع 256";
                d1.Distance = 30;
                d1.Duration = 120;
                drivers[i] = d1;
            }
            /*d1.UserID = 2;
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
            */
            string jsonString = "";
            //DataTable dt = new clsTripRequest().get(userId, userType);
            jsonString = JsonConvert.SerializeObject(drivers);
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };

            
        }

        // POST api/favdriver
        public HttpResponseMessage Post([FromBody]FavDriver driver)
        {
            int id = new clsFavDriver().insert(driver);
            string jsonString = "{ \"success\": { \"id\": "+ id.ToString()+"  } }"; ;
            
           // jsonString = JsonConvert.SerializeObject("");
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
        }

        // PUT api/favdriver/5
        /*public HttpResponseMessage Put(int id, [FromBody]FavDriver driver)
        {
            string jsonString = "{ \"success\": { \"id\": "+id.ToString()+"  } }"; ;
            
            
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
        }*/

        // DELETE api/favdriver/5
        public HttpResponseMessage Delete(int id)
        {
            new clsFavDriver().Delete(id);
            string jsonString = "{ \"success\": { \"id\": " + id.ToString() + "  } }"; ;


            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
        }

    }
}
