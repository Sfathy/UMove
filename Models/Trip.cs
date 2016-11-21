using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMoveNew.Models
{
    public class Trip
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public string InstKey { get; set; }
        public decimal SourceLat { get; set; }
        public decimal SourceLag { get; set; }
        public decimal DestLat { get; set; }
        public decimal DestLag { get; set; }

        public int DriverID { get; set; }
        public int CustomerID { get; set; }

        public int tripType { get; set; }

        public int Status { get; set; }
        public decimal Cost { get; set; }
        public decimal TripDuration { get; set; }

        public decimal TripCost { get; set; }
        public string DeliveryType { get; set; }
        public DateTime PicUpDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string PicUpType { get; set; }
        public string Note { get; set; }
        public string SourceLocationText { get; set; }
        public string DeliveryLocationText { get; set; }
        public List<TripService> tripService { get; set; }
        public List<Item> ItemsList { get; set; }
        public List<TripQuestions> TripQuestionsList { get; set; }
        public decimal destination { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }
}