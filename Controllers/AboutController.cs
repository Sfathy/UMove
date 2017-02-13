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
    public class AboutController : ApiController
    {
        // GET api/about
        public HttpResponseMessage Get()
        {
            string sql = "Select ParamterName,ParamterValue From  Settings Where ID=7";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
         //   string jsonString = "{ \"URL\": { \"url\": http://umove2.mline-ksa1.com/ } }";
            string jsonString = "{\"" + dt.Rows[0]["ParamterName"].ToString() + "\":\"" + dt.Rows[0]["ParamterValue"].ToString()+"\"}";
            // DataTable dt = new clsTripRequest().get(userId, userType);

            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
        }

        // GET api/about/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/about
        public void Post([FromBody]string value)
        {
        }

        // PUT api/about/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/about/5
        public void Delete(int id)
        {
        }
    }
}
