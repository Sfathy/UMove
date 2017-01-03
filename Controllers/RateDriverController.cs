using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UMoveNew.Controllers.AppCode;
using UMoveNew.Models;

namespace UMoveNew.Controllers
{
    public class RateDriverController : ApiController
    {
        // GET api/ratedriver
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        
        // GET api/ratedriver/5
        public HttpResponseMessage Get(int driverId)
        {
            //List<RateDriver> drivers = new List<RateDriver>();
            
            clsUserRate cRate = new clsUserRate();
            RateDriver d1 = cRate.get(driverId);
          
            DataTable dt = new DataTable();
            dt.Columns.Add("UserID");
            dt.Columns.Add("UserName");
            dt.Columns.Add("Rate");
            DataRow dr = dt.NewRow();
            dr["UserID"] = d1.UserID;
            dr["UserName"] = d1.Name;
            dr["Rate"] = d1.Rate;
            dt.Rows.Add(dr);
            string jsonString = "";
            
            jsonString = JsonConvert.SerializeObject(dt);
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
            
        }

        // POST api/ratedriver
        public HttpResponseMessage Post([FromBody]RateDriver Rate)
        {
            clsUserRate cRate = new clsUserRate();
           int res= cRate.insert_DriverRate(Rate);
           string jsonString = "";
           if (res>0)
           {
                jsonString = "{ \"success\": { \"id\": "+res+" } }";
           }
           else
           {
               jsonString = "{ \"error\": { \"code\": 1, \"message\": \"Error while adding new Rate\"  } }";
           }

            // jsonString = JsonConvert.SerializeObject("");
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
        }

        // PUT api/ratedriver/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/ratedriver/5
        public void Delete(int id)
        {
        }
    }
}
