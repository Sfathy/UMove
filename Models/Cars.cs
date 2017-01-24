using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMoveNew.Models
{
    public class Cars
    {
        public int ID { get; set; }
        public string CarType { get; set; }
        public string CarModel { get; set; }
        public string CarYear { get; set; }
        public string CarCondition { get; set; }
        public int NumOFSeats { get; set; }
        public int MaxWidth { get; set; }
        public int hight { get; set; }
        public int UserID { get; set; }
        public int Active { get; set; }
    }
}