using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMoveNew.Models
{
    public class Installation
    {
        public int ID { get; set; }
        public string apiKey { get; set; }
        public string appIdentifier { get; set; }
        public string appName { get; set; }
        public string appVersion { get; set; }
        //public int DeviceID { get; set; }
        public string deviceType { get; set; }
      
        public string deviceToken { get; set; }
        public string timezone { get; set; }
        public string InstallationKey { get; set; }
    }
}