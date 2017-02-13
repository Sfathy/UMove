using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMoveNew.Models
{
    public class changePassword
    {
        public int userID { get; set; }
        public string oldPassword { get; set; }

        public string newPassword { get; set; }
    }
}