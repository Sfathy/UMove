using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMoveNew.Models
{
    public class UserPhones
    {
        public int ID { get; set; }
        public int UserID { get; set; }

        public string PhoneNo { get; set; }
    }
}