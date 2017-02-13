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
    public class FavLocController : ApiController
    {
        // GET api/favloc
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/favloc/5
        public HttpResponseMessage Get(int userID)
        {
            string jsonString = string.Empty;

            clsFavLoc loc = new clsFavLoc();
            List<UserLocation> locs = loc.get(userID);
            jsonString = JsonConvert.SerializeObject(locs);
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
        }

        // POST api/favloc
        // add fav location for the user
        public HttpResponseMessage Post([FromBody]UserLocation userLoc)
        {
            string jsonString = string.Empty;
            
            clsFavLoc loc = new clsFavLoc();
            int id = loc.insert(userLoc);
            if(id > 0)
            {
                jsonString = "{ \"success\": { \"id\":" + id.ToString() + "  } }";
            }
            else
            {
                jsonString = "{ \"error\": { \"code\": 1, \"message\": \"Error while adding new locatino\"  } }"; ;
            }
            
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
        }

        // PUT api/favloc/5
        public HttpResponseMessage Put(int id, [FromBody]UserLocation userLoc)
        {
            string jsonString = string.Empty;

            clsFavLoc loc = new clsFavLoc();
            loc.update(id,userLoc);
            if (id > 0)
            {
                jsonString = "{ \"success\": { \"id\":" + id.ToString() + "  } }";
            }
            else
            {
                jsonString = "{ \"error\": { \"code\": 1, \"message\": \"Error while updating new location\"  } }"; ;
            }

            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
        }

        // DELETE api/favloc/5
        public HttpResponseMessage Delete(int id)
        {
            string jsonString = string.Empty;
            clsFavLoc loc = new clsFavLoc();
           int res= loc.Delete(id);
            if (res>0)
            {
                jsonString = "{ \"success\": { \"id\":" + id.ToString() + "  } }";
            }
            else
            {
                jsonString = "{ \"error\": { \"code\": 1, \"message\": \"Error while Deleting  location\"  } }"; ;
            }
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
        }
    }
}
