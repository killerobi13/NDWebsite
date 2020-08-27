using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewDawnWeb.Models
{
    public class TicketReply
    {
        public int Id { get; set; }

        public Ticket Ticket { get; set; }

        public string HtmlContent { get; set; }

        public DateTime ReplyDate { get; set; }

        public User User { get; set; }

    }
}
