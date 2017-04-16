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
    public class AcceptRequestController : ApiController
    {
        // GET api/acceptrequest
       /* public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/acceptrequest/5
        public string Get(int id)
        {
            return "value";
        }*/
        public class acceptTripModel
        {
            public int RequestID { get; set; }
            public string InstallationKey { get; set; }
            public int UserID { get; set; }
        }
        // POST api/acceptrequest
        public HttpResponseMessage Post([FromBody]acceptTripModel acceptTrip)
        {
            string jsonRes = "";
            try
            {
                clsTripRequest trip = new clsTripRequest();
                TripRequest t = trip.get(acceptTrip.RequestID);
                if (t.Status == (int)clsTripRequest.TripStatus.Request)
                {
                    trip.Accept(acceptTrip.RequestID, acceptTrip.UserID);

                    //get driver info
                    clsUser u = new clsUser();
                    DataTable dtDriver = u.get(acceptTrip.UserID);

                    //get request info
                    TripRequest userTrip = trip.get(acceptTrip.RequestID);

                    //get customer . Token
                    string customerDeviceToken = u.getUserDeviceToken(userTrip.UserID);


                    //send notification to the user with the driver information
                    AndroidGcmPushNotification not = new AndroidGcmPushNotification();
                    //string jsonString = "{ \"TripAccepted\": { \"id\": " + acceptTrip.RequestID.ToString() + " ,\"DriverName\":\""+dtDriver.Rows[0]["Name"].ToString()+"\" } }";
                    var message = new
                    {
                        to = customerDeviceToken,
                        notification = new
                        {
                            title = "Your Trip Accepted",
                            body = " Your trip accepted by "+ dtDriver.Rows[0]["Name"].ToString(),
                            status = "Accepted",
                            id = acceptTrip.RequestID.ToString()
                        }
                    };
                    //string jsonString = "{ \"TripAccepted\": {\"Status\":\"Accepted\", \"id\": " + acceptTrip.RequestID.ToString() + "  } }";
                    //jsonString = JsonConvert.SerializeObject(dtDriver);
                    //not.SendGcmNotification("", new string[] { customerDeviceToken }, jsonString);
                    not.SendNotification("AAAA0-XrarI:APA91bEReLIPg2bjfuuPshOiO3GbDeFg7irdrAMF3h2ErPhsf2LOOEGLP4C0Hz2CKjzWspoK0V7JwLRTXs1Kz-fQikKZG2hZNikWrAxJK1gLueNJ9SuB5JU_3aF_b-dAtiTHrEzXA7fB-Z59suJsTBvI3DODJwpusA", "910095510194", customerDeviceToken, message,"Trip Accepted");
                    jsonRes = "{ \"success\": { \"id\": " + acceptTrip.RequestID.ToString() + "  } }";
                }
                else
                {
                    jsonRes = "{ \"error\": { \"code\": 4, \"message\": \"trip already accepted\"  } }";
                }
            }
            catch(Exception e)
            {
                jsonRes = "{ \"error\": { \"code\": 3, \"message\": \"can't accept trip\"  } }";
            }
            return new HttpResponseMessage() { Content = new StringContent(jsonRes, System.Text.Encoding.UTF8, "application/json") };
        }

        // PUT api/acceptrequest/5
       /* public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/acceptrequest/5
        public void Delete(int id)
        {
        }*/
    }
}
