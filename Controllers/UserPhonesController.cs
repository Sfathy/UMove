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
            List<UserPhones> userPhones = new clsUserPhones().get(userId);
            string jsonString = "";
            jsonString = JsonConvert.SerializeObject(userPhones);
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json") };
        }

        // POST api/userphones
        public HttpResponseMessage Post([FromBody]UserPhones Phone)
        {
            clsUserPhones clsuserphone = new clsUserPhones();
            int res = clsuserphone.insert(Phone);

            string jsonString = "";
            if (res > 0)
            {
                jsonString = "{ \"success\": { \"id\":" + res.ToString() + "  } }";
            }
            else
            {
                jsonString = "{ \"error\": { \"code\": 3, \"message\": \"can't save User Phone\"  } }";
            }
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json") };
        }

        // PUT api/userphones/5
        public HttpResponseMessage Put(int id, [FromBody]UserPhones Phone)
        {
            clsUserPhones clsuserphone = new clsUserPhones();
            int res = clsuserphone.update(id, Phone);

            string jsonString = "";
            if (res > 0)
            {
                jsonString = "{ \"success\": { \"id\":" + res.ToString() + "  } }";
            }
            else
            {
                jsonString = "{ \"error\": { \"code\": 3, \"message\": \"can't Update User Phone\"  } }";
            }
            // jsonString = JsonConvert.SerializeObject("");
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json") };
        }

        // DELETE api/userphones/5
        public HttpResponseMessage Delete(int id)
        {
            clsUserPhones clsuserphone = new clsUserPhones();
            int res = clsuserphone.Delete(id);

            string jsonString = "";
            if (res > 0)
            {
                jsonString = "{ \"success\": { \"id\":" + res.ToString() + "  } }";
            }
            else
            {
                jsonString = "{ \"error\": { \"code\": 3, \"message\": \"can't Update User Phone\"  } }";
            }
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json") };
        }
    }
}
