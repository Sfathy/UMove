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
    public class UserPhonesController : ApiController
    {
        // GET api/userphones
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/userphones/5
        public HttpResponseMessage Get(int userId)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("PhoneNo");
            dt.Columns.Add("ID");
            DataRow dr = dt.NewRow();
            dr["PhoneNo"] = "01212121212";
            dr["ID"] = 1;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["PhoneNo"] = "01010101010";
            dr["ID"] = 2;
            dt.Rows.Add(dr);

            string jsonString = "";
            //DataTable dt = new clsTripRequest().get(userId, userType);
            jsonString = JsonConvert.SerializeObject(dt);
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
        }
        public class UserPhones
        {
            public int ID { get; set; }
            public int UserID { get; set; }

            public string  PhoneNo { get; set; }
        }
        // POST api/userphones
        public HttpResponseMessage Post([FromBody]UserPhones Phone)
        {
            string jsonString = "{ \"success\": { \"id\": 3  } }"; ;

            // jsonString = JsonConvert.SerializeObject("");
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
        }

        // PUT api/userphones/5
        public HttpResponseMessage Put(int id, [FromBody]UserPhones Phone)
        {
            string jsonString = "{ \"success\": { \"id\": "+id.ToString()+"  } }"; ;

            // jsonString = JsonConvert.SerializeObject("");
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
        }

        // DELETE api/userphones/5
        public HttpResponseMessage Delete(int id)
        {
            string jsonString = "{ \"success\": { \"id\": "+id.ToString()+"  } }"; ;

            // jsonString = JsonConvert.SerializeObject("");
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
        }
    }
}
