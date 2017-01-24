using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UMoveNew.Controllers.AppCode;

namespace UMoveNew.Controllers
{
    public class OpenedRequestController : ApiController
    {
        // GET api/openedrequest
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/openedrequest/5
        public HttpResponseMessage Get(decimal Latitude, decimal Longitude, int DriverID)
        {
            //DataTable dt = new DataTable();
            /*dt.Columns.Add("TripID");
            dt.Columns.Add("Duration");
            dt.Columns.Add("lat");
            dt.Columns.Add("lng");
            DataRow dr;
            for (int i = 0; i < 2; i++)
            {
                dr = dt.NewRow();
                dr["TripID"] = 9 + i;
                dr["Duration"] = 10 +i*10;
                dr["lat"] = 31.25621 + i;
                dr["lng"] = 25.3621 + i;
                dt.Rows.Add(dr);
            }
            */

            string s = "";
            List<string> ss = new List<string>();
            DataTable dt = new clsTripRequest().get(Latitude,Longitude);
            if (dt!=null)
            {
                dt.Columns.Remove("Route");
                s = JsonConvert.SerializeObject(dt); 
            }
            else
            {
                s= "{ \"error\": { \"code\": 3, \"message\": \"no trips around you\"  } }";
            }
            
            return new HttpResponseMessage() { Content = new StringContent(s.Trim(), System.Text.Encoding.UTF8, "application/jason") };
        }

        // POST api/openedrequest
        public void Post([FromBody]string value)
        {
        }

        // PUT api/openedrequest/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/openedrequest/5
        public void Delete(int id)
        {
        }
    }
}
