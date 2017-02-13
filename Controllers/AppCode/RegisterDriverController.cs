using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UMoveNew.Models;

namespace UMoveNew.Controllers.AppCode
{
    public class RegisterDriverController : ApiController
    {
        // GET api/registerdriver
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/registerdriver/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/registerdriver
        public HttpResponseMessage Post([FromBody]Driver driver)
        {
            string jsonString = "";
            clsUser u = new clsUser();
            int id = u.insert(driver);
            if (id != -1)
            {
                string sql = "insert into DriverCarDetails(UserID,CarDescription,CarNo) values(" + id.ToString() + ",'" + driver.CarDescription + "','" + driver.CarNo + "')";
                DataAccess.ExecuteSQLNonQuery(sql);
                jsonString = "{ \"success\": { \"id\":" + id.ToString() + "  } }";
                
            }
            else
            {
                jsonString = "{ \"error\": { \"code\": 1, \"message\": \"User name or mail exist\"  } }";
            }
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };

        }

        // PUT api/registerdriver/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/registerdriver/5
        public void Delete(int id)
        {
        }
    }
}
