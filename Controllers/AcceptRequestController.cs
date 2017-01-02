﻿using Newtonsoft.Json;
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

        // POST api/acceptrequest
        public HttpResponseMessage Post(int RequestID, string InstallationKey, int UserID)
        {
            string jsonRes = "";
            try
            {
                clsTripRequest trip = new clsTripRequest();
                TripRequest t = trip.get(RequestID);
                if (t.Status == (int)clsTripRequest.TripStatus.Request)
                {
                    trip.Accept(RequestID, UserID);

                    //get driver info
                    clsUser u = new clsUser();
                    DataTable dtDriver = u.get(UserID);

                    //get request info
                    TripRequest userTrip = trip.get(RequestID);

                    //get customer Device Token
                    string customerDeviceToken = u.getUserDeviceToken(userTrip.CustomerID);


                    //send notification to the user with the driver information
                    AndroidGcmPushNotification not = new AndroidGcmPushNotification();
                    string jsonString = string.Empty;
                    jsonString = JsonConvert.SerializeObject(dtDriver);
                    //not.SendGcmNotification("", new string[] { customerDeviceToken }, jsonString);
                    not.SendNotification("AIzaSyAUzTKuzVyD4ERLmaQb49bt4HnwioeVgT8", "", customerDeviceToken, JsonConvert.SerializeObject(trip));
                    jsonRes = "{ \"success\": { \"id\": " + RequestID.ToString() + "  } }";
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
            return new HttpResponseMessage() { Content = new StringContent(jsonRes, System.Text.Encoding.UTF8, "application/jason") };
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
