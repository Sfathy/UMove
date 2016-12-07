using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMoveNew.Models
{
    public class Triplegs
    {
        public propt distance { get; set; }
        public propt duration { get; set; }


        public string end_address { get; set; }

        public Point end_location { get; set; }

        public string start_address { get; set; }

        public Point start_location { get; set; }

        public List<TripRouteSteps> steps { get; set; }

    }
    public class TripRoute
    {

        public List<Triplegs> legs { get; set; }
        public string summary { get; set; }

        

       

        


    }
    public class Point
    {
        public decimal lat { get; set; }
        public decimal lng { get; set; }
        public Point( decimal lat,decimal lng)
        {
            this.lat = lat;
            this.lng = lng;
        }
    }
    public class propt
    {
        public string text { get; set; }
        public decimal value { get; set; }
        public propt(string text,decimal value)
        {
            this.text = text;
            this.value = value;
        }
    }
    public class TripRouteSteps
    {
        public propt distance { get; set; }
        public propt duration { get; set; }

        public Point end_location { get; set; }

        public string html_instructions { get; set; }

        public Point start_location { get; set; }

       // public string end_location_lng { get; set; }

        public string travel_mode { get; set; }

    }
}