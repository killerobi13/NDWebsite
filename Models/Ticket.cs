using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewDawnWeb.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string HtmlContent { get; set; }
        public DateTime PublishedDate { get; set; }
        public int  State { get; set; }
        //Solved
        //Solving
        //Unappointed
        public User Issuer { get; set; }
        public User Solver { get; set; }

        public ICollection<TicketReply> TicketReplies { get; set; }

    }
}
