using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMoveNew.Models
{
    public class FavDriver
    {
        public int ID { get; set; }
        public int UserID { get; set; }

        public int DriverID { get; set; }

        public string DriverName { get; set; }
        public string CarDescription { get; set; }

        public string CarNo { get; set; }

        public double Duration { get; set; }
        public double Distance { get; set; }
    }
}