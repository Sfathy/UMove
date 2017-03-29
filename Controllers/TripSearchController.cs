using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UMoveNew.Controllers.AppCode;
using UMoveNew.Models;

namespace UMoveNew.Controllers
{
    public class TripSearchController : ApiController
    {
        public HttpRequestMessage Get(int carCategory, string startAddress = "", string endAddress = "", DateTime? searchDate = null)
        {
            string jsonString = "";
            List<TripRequest> trips = new clsTripRequest().SearchTrip(searchDate, carCategory,startAddress,endAddress);
            if (trips != null)
                jsonString = JsonConvert.SerializeObject(trips);
                
            else
                jsonString = "{ \"error\": { \"code\": 3, \"message\": \"can't find trips\"  } }";
                return new HttpRequestMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
        }
    }
}
