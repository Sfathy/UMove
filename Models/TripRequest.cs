using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMoveNew.Models
{
    public class TripRequest
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public string InstKey { get; set; }
        public decimal SourceLat { get; set; }
        public decimal Sourcelong { get; set; }
        public decimal DestLat { get; set; }
        public decimal DestLong { get; set; }

        public int DriverID { get; set; }
        public int CustomerID { get; set; }

        public int tripType { get; set; }
        public int PaymentMethod { get; set; }
        public int CarCategory { get; set; }
        public int Status { get; set; }
        public DateTime PicUpDate { get; set; }
        public Decimal Cost { get; set; }
        public Decimal Distance { get; set; }
        public Decimal WaitingTime { get; set; }
        
    }
}