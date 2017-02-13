using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UMoveNew.Controllers.AppCode;

namespace UMoveNew.Controllers
{
    public class BalanceController : ApiController
    {
        // GET api/balance
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/balance/5
        public HttpResponseMessage Get(int userId,int userType)
        {
            string jsonString = "";
           
             DataTable dt = new clsUserBalance().getBalance(userId);
             jsonString = JsonConvert.SerializeObject(dt);
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
        }

        // POST api/balance
        public void Post([FromBody]string value)
        {
        }

        // PUT api/balance/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/balance/5
        public void Delete(int id)
        {
        }
    }
}
