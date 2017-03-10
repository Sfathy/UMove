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
        
        [HttpPost]
        public IHttpActionResult ReserveTrip([FromBody] ReservedTrip reservedTrip)
        {
            int res = new clsTripRequest().ReserveTrip(reservedTrip);
            switch (res)
            {
                case -1:
                    return BadRequest("Number of seats not available");
                    break;
                case 0:
                    return BadRequest("Can't save reservation");
                    
                    break;
                default:
                    reservedTrip.ID = res;
                    return Created("",reservedTrip);
                    break;
            }
            return BadRequest("Can't save reservation");
             
        }
    }
}
