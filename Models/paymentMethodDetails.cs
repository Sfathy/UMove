using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMoveNew.Models
{
    public class paymentMethodDetails
    {
        public int UserID { get; set; }
        public string MethodName { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int CardType { get; set; }
        public string CardNumber { get; set; }
        public string CardUserName { get; set; }
        
    }
}