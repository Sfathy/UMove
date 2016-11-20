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
    public class CarCategoryController : ApiController
    {
        // GET api/carcategory
        public HttpResponseMessage Get()
        {
            string sql = "select * from CarCategory";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            string jsonString = string.Empty;
            jsonString = JsonConvert.SerializeObject(dt);

            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
        }

        // GET api/carcategory/5
       /* public string Get(int id)
        {
            return "value";
        }

        // POST api/carcategory
        public void Post([FromBody]string value)
        {
        }

        // PUT api/carcategory/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/carcategory/5
        public void Delete(int id)
        {
        }*/
    }
}
