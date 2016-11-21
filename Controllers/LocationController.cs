using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UMoveNew.Controllers.AppCode;
using UMoveNew.Models;
using System.Device.Location;
namespace UMoveNew.Controllers
{
    public class LocationController : ApiController
    {
        // GET api/location
      

        // GET api/location/5
        public List<UserLocation> Get(int id)
        {
            clsUserLocation location = new clsUserLocation();
            return location.get(id);
        }

        // POST api/location
        public HttpResponseMessage Post([FromBody] UserLocation loc)
        {

            string jsonString = string.Empty;
            clsUserLocation location = new clsUserLocation();
            List< UserLocation> userloc = location.get(loc.UserID);
            int id = 0;
            if (userloc.Count == 0)
                id = location.insert(loc);
            else
                id = location.update(userloc[0].ID, loc);
            if (id > 0)
            {
                jsonString = "{ \"success\": { \"id\":" + id.ToString()+ "  } }";
            }
            else
            {
                jsonString = "{ \"error\": { \"code\": 3, \"message\": \"can't save or update location\"  } }";
            }
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
        }

        // PUT api/location/5
        public HttpResponseMessage Put(int id, [FromBody] UserLocation loc)
        {
            string jsonString = string.Empty;
            clsUserLocation location = new clsUserLocation();
            location.update(id,loc);
            jsonString = "{ \"success\": { \"id\":" + id.ToString() + "  } }";
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
        }

        // DELETE api/location/5
        public void Delete(int id)
        {
        }
    }
}
