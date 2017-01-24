using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UMoveNew.Controllers.AppCode;

namespace UMoveNew.Controllers
{
    public class VerfiyNoController : ApiController
    {
        // GET api/verfiyno
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/verfiyno/5
        public HttpResponseMessage Get(int code, int userID)
        {
            string vNo = new clsUser().getVerificationNo(userID);
            string jsonString = "";
            if (string.IsNullOrEmpty(vNo))
            {
                jsonString = "{ \"success\": { \"id\":"+userID.ToString()+" } }";
                // DataTable dt = new clsTripRequest().get(userId, userType);
            }
            else
            {
                if(vNo == code.ToString())
                {
                    jsonString = "{ \"success\": { \"id\":" + userID.ToString() + " } }";
                }
                else
                {
                    jsonString = "{ \"error\": { \"code\":3, \"message\":\" code not verified\"  } }";
                }
            }
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
        }

        // POST api/verfiyno
        public void Post([FromBody]string value)
        {
        }

        // PUT api/verfiyno/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/verfiyno/5
        public void Delete(int id)
        {
        }
    }
}
