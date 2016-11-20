using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UMoveNew.Controllers
{
    public class PaymentMethodController : ApiController
    {
        // GET api/paymentmethod
        public HttpResponseMessage Get()
        {
            string sql = "select * from PaymentMethod";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            string jsonString = string.Empty;
            jsonString = JsonConvert.SerializeObject(dt);
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
            
        }

        // GET api/paymentmethod/5
      /*  public string Get(int id)
        {
            return "value";
        }

        // POST api/paymentmethod
        public void Post([FromBody]string value)
        {
        }

        // PUT api/paymentmethod/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/paymentmethod/5
        public void Delete(int id)
        {
        }*/
    }
}
