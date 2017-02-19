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
    public class BidsController : ApiController
    {
        // GET api/Bids/5
        public HttpResponseMessage Get(int id)
        {
            clsBids cbid = new clsBids();
            Bid bid = cbid.get(id);
            if (bid != null)
                return Request.CreateResponse(HttpStatusCode.OK, bid);
            else
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "no bid with this ID");
        }

        // POST api/Bids
        public HttpResponseMessage Post([FromBody]Bid bid)
        {
            clsBids cbid = new clsBids();
            int id = cbid.insert(bid);
            if (id != 0)
                return Request.CreateResponse(HttpStatusCode.Created, bid);
            else
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "can't create bid");
        }

        // PUT api/Bids/5
        public HttpResponseMessage Put(int id, [FromBody]Bid bid)
        {
            clsBids cbid = new clsBids();
            cbid.update(id, bid);
            if (id != 0)
                return Request.CreateResponse(HttpStatusCode.Created, bid);
            else
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "can't create bid");
        }

        // DELETE api/Bids/5
        public void Delete(int id)
        {
        }
    }
}
