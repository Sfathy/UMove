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
        public IHttpActionResult Get(int carCategory, string startAddress="", string endAddress="", DateTime? searchDate = null)
        {

            List<TripRequest> trips = new clsTripRequest().SearchTrip(searchDate, carCategory,startAddress,endAddress);
            if (trips != null)
                return Ok(trips);
            else
                return BadRequest("Can't find trips");
        }
    }
}
