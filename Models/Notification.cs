using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMoveNew.Models
{
    public class Notification
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public DateTime NotDate { get; set; }
        public string Description { get; set; }
    }
}