﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMoveNew.Models
{
    public class RateDriver
    {
        public int ID { get; set; }
        public int TripID { get; set; }
        public int DriverID { get; set; }
        public decimal Rate { get; set; }

        public string Name { get; set; }
        public int UserID { get; set; }

        public string Feedback { get; set; }
    }
}