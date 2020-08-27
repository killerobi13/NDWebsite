using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewDawnWeb.Models
{
    public class IMItem
    {        
        public int Id { get; set; }
        public int ItemCode { get; set; }
        public string IconLink { get; set; }
        public string HoverLink { get; set; }
        public string Name { get; set; }
        public int? Price { get; set; } 
        public string Description { get; set; }       
        public int Category { get; set; }
        public short Discount { get; set; }
        public bool Enabled { get; set; }

    }
}
