using Newtonsoft.Json.Linq;
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

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
        public Decimal Cost { get; set; }
        public Decimal Distance { get; set; }
        public Decimal WaitingTime { get; set; }

     //   public List<TripRouteSteps> steps { get; set; }
        public string   DriverName { get; set; }
        public string DriverPhone { get; set; }
        public string DriverCarNo { get; set; }
        public string Route { get; set; }
        public double Duration { get; set; }
        public string  StartAddress { get; set; }
        public string EndAddress { get; set; }

        public string Steps { get; set; }
    }
}