using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewDawnWeb.Models
{
    public class CoinsOffer
    {
        public int Id { get; set; }
        public int BaseAmount { get; set; }
        public int BonusAmount { get; set; }
        public int Name { get; set; }
        public int Price { get; set; }
    }
}
