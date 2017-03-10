using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMoveNew.Models
{
    public class TripRequest
    {
        public enum Freq
        {
            Day=1,
            Week=2,
            Month=3
        }
        public enum tripType
        {
            byUser =1,
            byDriver=2
        }
        public int ID { get; set; }

        public int UserID { get; set; }

        public string InstKey { get; set; }
        public decimal SourceLat { get; set; }
        public decimal Sourcelong { get; set; }
        public decimal DestLat { get; set; }
        public decimal DestLong { get; set; }

        public int DriverID { get; set; }
        public int CustomerID { get; set; }

        public int TripType { get; set; }
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
        public string DriverPhoto { get; set; }

        public decimal DriverRate { get; set; }
        public string UserName { get; set; }
        public string UserPhone { get; set; }
        public string DriverCarNo { get; set; }
        public string DriverCarDescription { get; set; }
        public bool IsFav { get; set; }
        public string Route { get; set; }
        public double Duration { get; set; }
        public string  StartAddress { get; set; }
        public string EndAddress { get; set; }

        public string EstimatedCost  { get; set; }

        public string EstimatedDuration { get; set; }
        public string EstimatedDistance { get; set; }
        public string Steps { get; set; }
        public int NoOfSeats { get; set; }
        public int TripCreator { get; set; }
        public TimeSpan EstimatedStartTime { get; set; }
        public TimeSpan EstimatedEndTime { get; set; }
        public Decimal FeesPerChair { get; set; }
        public Decimal FeesforCar { get; set; }
        public bool IsSchedule { get; set; }
        public int Every { get; set; }
        public int Frequency { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }



    }
}