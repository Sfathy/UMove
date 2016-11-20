using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMoveNew.Models
{
    public class Item
    {
        public int ItemID { get; set; }
        
        public int ItemType { get; set; }
        public int CatID { get; set; }
        public int SubCatID { get; set; }
        public int NoOfUnits { get; set; }
        public decimal Width { get; set; }

        public decimal Height { get; set; }

        public decimal Length { get; set; }

        public decimal Wight { get; set; }

        public string Description { get; set; }
        public string ImageURL { get; set; }
    }
}