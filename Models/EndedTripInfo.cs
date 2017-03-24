using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMoveNew.Models
{
    public class EndedTripInfo
    {
        public JObject Steps { get; set; }
        public List<ReservedTrip> PickedUpUsers { get; set; }
        public int TripID { get; set; }
    }
}