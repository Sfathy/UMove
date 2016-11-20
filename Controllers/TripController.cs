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
    public class TripController : ApiController
    {
        // GET api/trip
        public List<Trip> Get()
        {
            return new List<Trip>();
        }

        // GET api/trip/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/trip
        public void Post([FromBody]Trip trip)
        {
            clsTrip t = new clsTrip();
            t.insert(trip);
        }

        // PUT api/trip/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/trip/5
        public void Delete(int id)
        {
        }
    }
}
