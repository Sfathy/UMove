using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMoveNew.Models
{
    public class SharedTrip : Trip
    {
        public string PicUpTime { get; set; }
        public string DeliveryTime { get; set; }
        public bool Repeted { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int RepetedType { get; set; }
        public int SharetripType { get; set; }
    }
}