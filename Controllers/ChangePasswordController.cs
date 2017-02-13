using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UMoveNew.Models;

namespace UMoveNew.Controllers
{
    public class ChangePasswordController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        
        // POST api/<controller>
        public HttpResponseMessage Post([FromBody] changePassword n )
        {
            string jsonString = string.Empty;
            string sql = "select * from Users Where ID=" + n.userID + " And Password='" + n.oldPassword + "'";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            if (dt.Rows.Count > 0)
            {
                sql = "Update Users set Password='" + n.newPassword + "' Where ID=" + n.userID;
                DataAccess.ExecuteSQLNonQuery(sql);
                jsonString = "{ \"success\": { \"id\": " + n.userID + "  } }";
            }
            else 
            {
                jsonString = "{ \"error\": { \"code\": 3, \"message\": \"Wrong Password\"  } }";
            }
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}