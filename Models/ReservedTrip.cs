using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMoveNew.Models
{
    public class ReservedTrip
    {
        public enum ReservationStatus
        {
            pending = 1,
            accepted = 2,
            canceled = 3

        }
        public int ID { get; set; }
       
            public int TripID { get; set; }
            public int NoOfSeats { get; set; }
            public DateTime ReservationDate { get; set; }
            public int UserID { get; set; }
            public int Status { get; set; }

            public string UserName { get; set; }
            public string UserPhone { get; set; }
        
    }
}