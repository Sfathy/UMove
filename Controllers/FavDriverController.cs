using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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
        public HttpResponseMessage Get(int userId,decimal lat = 0 ,decimal lng = 0)
        {
            //use this URL to get the distance between user and driver
            //https://maps.googleapis.com/maps/api/distancematrix/json?units=metric&origins=29.857218,%2031.371445&destinations=29.842767,%2031.333465&key=AIzaSyApwh5jfaziQLqxrDGMRrChZQkCs0vavsA

            List<FavDriver> drivers = new clsFavDriver().get(userId);
            FavDriver d1 = new FavDriver();
            for (int i = 0; i < drivers.Count; i++)
            {
                d1 = new FavDriver();
                d1 = drivers[i];
                if (d1.DriverLat != null && d1.DriverLat != 0 && d1.DriverLng != null && d1.DriverLng != 0 & lat != 0 & lng !=0)
                {
                    clsUserLocation.dist mes = new clsUserLocation().getDistance(lat, lng, d1.DriverLat, d1.DriverLng);
                    d1.Distance = mes.distnation;
                    d1.Duration = mes.duration;
                }
                else
                {
                    d1.Distance = 0;
                    d1.Duration = 0;
                }
                drivers[i] = d1;
            }
            
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
