using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewDawnWeb.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
        public string Email { get; set; }
        public string PaypalTxnId { get; set; }
        public DateTime Date { get; set; }
        public User User { get; set; }
        public bool Valid { get; set; }
    }
}
