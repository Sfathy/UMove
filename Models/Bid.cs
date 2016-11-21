using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMoveNew.Models
{
    public class Bid
    {
        public int ID { get; set; }
        public int TripID { get; set; }
        public Decimal Price { get; set; }
        public int TruckType { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime BidExpiration { get; set; }
        public string Note { get; set; }
        public string TermCondition { get; set; }
        public int UserID { get; set; }
        public int Accepted { get; set; }

    }
}