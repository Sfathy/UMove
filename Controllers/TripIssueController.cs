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
    public class TripIssueController : ApiController
    {
        // GET api/tripissue
        public HttpResponseMessage Get()
        {
           // clsTripIssue issue = 
            DataTable dt = new  clsTripIssue().getAllIssues();
            /*dt.Columns.Add("ID");
            dt.Columns.Add("Issue");
            DataRow dr = dt.NewRow();
            dr["ID"] = 1;
            dr["Issue"] = "I Lost an Item";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["ID"] = 2;
            dr["Issue"] = "I need a copy of my receipt";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["ID"] = 3;
            dr["Issue"] = "I was charged a free cancellation";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["ID"] = 4;
            dr["Issue"] = "I used a wrong payment method";
            dt.Rows.Add(dr);*/
            string jsonString = "";
            //DataTable dt = new clsTripRequest().get(userId, userType);
            jsonString = JsonConvert.SerializeObject(dt);
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
            
            
        } 

        // GET api/tripissue/5
        public HttpResponseMessage Get(int tripId)
        {
            DataTable dt = new clsTripIssue().getTripIssues(tripId);
            /*
            List<TripIssues> tripIssues = new List<TripIssues>();
            TripIssues d1 = new TripIssues();
            d1.UserID = 2;
            d1.DriverID = 4;
            d1.IssueID = 2;
            d1.TripID = tripId;
            tripIssues.Add(d1);
            */
            string jsonString = "";
            //DataTable dt = new clsTripRequest().get(userId, userType);
            jsonString = JsonConvert.SerializeObject(dt);
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
            
        }

        // POST api/tripissue
        public HttpResponseMessage Post([FromBody]TripIssues tripIssue)
        {
            clsTripIssue issue = new clsTripIssue();
            int id = issue.insert(tripIssue);
            string jsonString = "{ \"success\": { \"id\": "+ id.ToString() +"  } }"; ;

            // jsonString = JsonConvert.SerializeObject("");
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
        }

        // PUT api/tripissue/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/tripissue/5
        public void Delete(int id)
        {
        }
    }
}
