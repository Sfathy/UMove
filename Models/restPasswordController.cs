using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UMoveNew.Controllers.AppCode;

namespace UMoveNew.Models
{
    public class restPasswordController : ApiController
    {
        // GET api/restpassword
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/restpassword/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/restpassword
        public string Post([FromBody] LoginModel Login)
        {
            clsInstallation inst = new clsInstallation();
            DataTable dt2 = inst.get(Login.InstallationKey);
            clsUser user = new clsUser();
            if (dt2 != null && dt2.Rows != null && dt2.Rows.Count > 0)
            {
                if (user.login(Login.Email, Login.Password) > 0)
                {
                    string jsonString = string.Empty;
                    jsonString = JsonConvert.SerializeObject(user.restPassword(Login.Email));
                    return jsonString;
                }
                else
                {
                    return "{ \"error\": { \"code\": 1, \"message\": \"User Not Exist\"  } }";
                }
            }
            else
            {
                return "{ \"error\": { \"code\": 1, \"message\": \"Error message\"  } }";
            }
        }

        // PUT api/restpassword/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/restpassword/5
        public void Delete(int id)
        {
        }
    }
}
