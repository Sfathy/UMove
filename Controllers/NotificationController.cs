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
    public class NotificationController : ApiController
    {
        // GET api/notification
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/notification/5
        public HttpResponseMessage Get(int userId)
        {
            List<Notification> nots = new clsNotification().get(userId);
            
            string jsonString = "";
            //DataTable dt = new clsTripRequest().get(userId, userType);
            jsonString = JsonConvert.SerializeObject(nots);
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json") };
        }

        // POST api/notification
        public HttpResponseMessage Post([FromBody]Notification not)
        {
            clsNotification clsNot = new clsNotification();
            int res = clsNot.insert(not);
            string jsonString = "";
            if (res > 0)
            {
                jsonString = "{ \"success\": { \"id\":" + res.ToString() + "  } }";
            }
            else {
                jsonString = "{ \"error\": { \"code\": 3, \"message\": \"can't save Notification\"  } }";
            }
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json") };
        }

        // PUT api/notification/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/notification/5
        public void Delete(int id)
        {
        }
    }
}
