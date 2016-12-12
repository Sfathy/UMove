using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMoveNew.Models
{
    public class TripIssues
    {
        public int ID { get; set; }
        public int TripID { get; set; }
        public int UserID { get; set; }
        public int IssueID { get; set; }

        public int DriverID { get; set; }


    }
}