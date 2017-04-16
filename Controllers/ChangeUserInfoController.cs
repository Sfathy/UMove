using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UMoveNew.Controllers
{
    public class ChangeUserInfoController : ApiController
    {
        // GET api/changename
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/changename/5
        public string Get(int id)
        {
            return "value";
        }
        public class ChangeUserName
        {
            public int UserID { get; set; }
            public string NewUserName { get; set; }
            public string NewUserMail { get; set; }
            public string NewUserPhone { get; set; }
        }
        // POST api/changename
        public HttpResponseMessage Post([FromBody]ChangeUserName NewName)
        {
            string fields = "";
            if (NewName.NewUserName != string.Empty && NewName.NewUserName != null)
                fields += " Name = '" + NewName.NewUserName+"'";
            if (NewName.NewUserPhone != string.Empty && NewName.NewUserPhone != null)
            {
                if (fields != string.Empty)
                    fields += ",";
                fields += " Phone = '" + NewName.NewUserPhone+"'";
            }
            if (NewName.NewUserMail != string.Empty && NewName.NewUserMail != null)
            {
                if (fields != string.Empty)
                    fields += ",";
                fields += " Email = '" + NewName.NewUserMail+"'";
            }
            string sql = "update users set " + fields + " where ID = " + NewName.UserID.ToString();
            int res = DataAccess.ExecuteSQLNonQuery(sql);
            string jsonString = "";
            if (res > 0)
            {
                jsonString = "{ \"success\": { \"id\": " + NewName.UserID.ToString() + "  } }"; 
            }
            else
                jsonString = "{ \"error\": { \"code\": 1, \"message\": \" Can not update \"  } }";

            // jsonString = JsonConvert.SerializeObject("");
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json") };
        }

        // PUT api/changename/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/changename/5
        public void Delete(int id)
        {
        }
    }
}
