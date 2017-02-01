using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using UMoveNew.Controllers.AppCode;
using UMoveNew.Models;

namespace UMoveNew.Controllers
{
    public class TripHistoryController : ApiController
    {
        // GET api/triphistory
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
      
        // GET api/triphistory/5
        public HttpResponseMessage Get(int userId, int userType=0, int isFuture = 0,int page = 0,int isActive =0)
        {
            int pageSize = clsSettings.Setting.PageSize;
            string jsonString = "";
            DataTable dt = new clsTripRequest().get(userId, userType,isFuture,isActive);
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                List<TripRequest> lst = dt.DataTableToList<TripRequest>();
                if (page != 0)
                {
                    if ((page - 1) * pageSize < lst.Count)
                    {
                        jsonString = JsonConvert.SerializeObject(lst.Skip((page - 1) * pageSize).Take(pageSize));
                    }
                    else
                    {
                        jsonString = "{ \"error\": { \"code\": 2, \"message\": \"no trips in this page \"  } }"; ;
                    }
                }
                 else
                {
                    jsonString = JsonConvert.SerializeObject(lst);
                }
                
            }
            else
            {
                jsonString = "{ \"error\": { \"code\": 3, \"message\": \"can't find trips for this user \"  } }"; ;
            }
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
        }

        // POST api/triphistory
        public void Post([FromBody]string value)
        {
        }

        // PUT api/triphistory/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/triphistory/5
        public void Delete(int id)
        {
        }
    }
}
