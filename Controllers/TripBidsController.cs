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
    public class TripBidsController : ApiController
    {

        // GET api/Bids/5
        public HttpResponseMessage Get(int tripId)
        {
            clsBids cbid = new clsBids();
            List<Bid> bids = cbid.getList(tripId);
            if (bids != null)
                return Request.CreateResponse(HttpStatusCode.OK, bids);
            else
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "no bid with this ID");
        }

        
    }
}
