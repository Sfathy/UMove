﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMoveNew.Models
{
    public class UserLocation
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string AccessToken { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public DateTime DateTime { get; set; }
    }
}