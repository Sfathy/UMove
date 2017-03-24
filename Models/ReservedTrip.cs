using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMoveNew.Models
{
    public class ReservedTrip
    {
        public int ID { get; set; }
       
            public int TripID { get; set; }
            public int NoOfSeats { get; set; }
            public DateTime ReserveDate { get; set; }
            public int UserID { get; set; }

        
    }
}