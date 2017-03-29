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
    public class ReserveTripController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get(int tripID, DateTime? reservationDate = null)
        {
            string jsonString = "";
            clsTripRequest t = new clsTripRequest();
            List<ReservedTrip> res = t.GetTripReservations(tripID, reservationDate);
            if (res != null && res.Count > 0)
                JsonConvert.SerializeObject(res);
            else
                jsonString = "{ \"error\": { \"code\": 3, \"message\": \"Can't find trip reservations\"  } }";
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
        }
        [HttpPost]
        public HttpResponseMessage ReserveTrip([FromBody] ReservedTrip reservedTrip)
        {
            string jsonString = "";
            int res = new clsTripRequest().ReserveTrip(reservedTrip);
            switch (res)
            {
                case -1:
                    jsonString = "{ \"error\": { \"code\": 3, \"message\": \"Number of seats not available\"  } }";
                    //return BadRequest("Number of seats not available");
                    break;
                case 0:
                    jsonString = "{ \"error\": { \"code\": 3, \"message\": \"Can't save reservation\"  } }";
                    
                    break;
                default:
                    reservedTrip.ID = res;
                    JsonConvert.SerializeObject(reservedTrip);
                    break;
            }
           // return BadRequest("Can't save reservation");
            jsonString = "{ \"error\": { \"code\": 3, \"message\": \"Can't save reservation\"  } }";
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
        }
    }
}
