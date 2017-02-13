using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMoveNew.Models
{
    public class Driver : Users
    {
        public string CarDescription { get; set; }
        public string CarNo { get; set; }
    }
}