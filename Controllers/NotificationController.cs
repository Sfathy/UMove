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
            List<Notification> nots = new List<Notification>();
            Notification n = new Notification();
            n.ID = 1;
            n.Description = "You won 30 Points";
            n.NotDate = new DateTime(2016, 12, 15, 4, 30, 00);
            n.UserID = 37;
            nots.Add(n);

            n = new Notification();
            n.ID = 2;
            n.Description = "You won 10 Points";
            n.NotDate = new DateTime(2016, 12, 15, 8, 30, 00);
            n.UserID = 37;
            nots.Add(n);

            string jsonString = "";
            //DataTable dt = new clsTripRequest().get(userId, userType);
            jsonString = JsonConvert.SerializeObject(nots);
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
        }

        // POST api/notification
        public void Post([FromBody]string value)
        {
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
