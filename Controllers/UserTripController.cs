using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UMoveNew.Controllers.AppCode;

namespace UMoveNew.Controllers
{
    public class UserTripController : ApiController
    {
        // GET api/UserTrip/5
        public HttpResponseMessage Get(int userId)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new clsTrip().get(userId));
        }
    }
}
