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

          
            DataTable dt = new clsTripRequest().get(Latitude,Longitude);
            JObject routs = (JObject)JsonConvert.DeserializeObject(dt.Rows[0]["Route"].ToString(), typeof(JObject));
            routs.Add("ID", dt.Rows[0]["ID"].ToString());
            routs.Add("dis", dt.Rows[0]["dis"].ToString());
            routs.Add("UserID", dt.Rows[0]["dis"].ToString());
            routs.Add("SourceLat", dt.Rows[0]["SourceLat"].ToString());
            routs.Add("SourceLong", dt.Rows[0]["SourceLong"].ToString());
            routs.Add("DestLat", dt.Rows[0]["DestLat"].ToString());
            routs.Add("DestLong", dt.Rows[0]["DestLong"].ToString());
            routs.Add("PicUpDate", dt.Rows[0]["PicUpDate"].ToString());
            //get driver info this isn't real data 
            routs.Add("Status", dt.Rows[0]["Status"].ToString());
            routs.Add("PaymentMethod", dt.Rows[0]["PaymentMethod"].ToString());
            routs.Add("CarCategory", dt.Rows[0]["CarCategory"].ToString());
            routs.Add("Distance", dt.Rows[0]["Distance"].ToString());
            routs.Add("WaitingTime", dt.Rows[0]["WaitingTime"].ToString());
            routs.Add("Cost", dt.Rows[0]["Cost"].ToString());
            //routs.Add("CarCategory", t.CarCategory);
            //routs.Add("Distance", t.Distance);
            //routs.Add("WaitingTime", t.WaitingTime);
            //routs.Add("Cost", t.Cost.ToString() + " LE");

            routs.Add("Steps", dt.Rows[0]["Route"].ToString());
            routs.Add("StartAddress", dt.Rows[0]["StartAddress"].ToString());
            routs.Add("EndAddress", dt.Rows[0]["EndAddress"].ToString());
            routs.Add("UserName", dt.Rows[0]["UserName"].ToString());
            routs.Add("UserPhone", dt.Rows[0]["UserPhone"].ToString());
            routs.Add("CarCategoryName", dt.Rows[0]["CarCategoryName"].ToString());
            string s = JsonConvert.SerializeObject(routs);
            string jsonString = "";
            //DataTable dt = new clsTripRequest().get(userId, userType);
            jsonString = JsonConvert.SerializeObject(dt);
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
