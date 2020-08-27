using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewDawnWeb.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public int GmLevel { get; set; }
        //lv 3 = publish news
        //lv 2 = publish events
        //lv 1 = ban user
        public bool IsLoginBanned { get; set; }

        public int Coins { get; set; }
        public string ConfirmationToken { get; set; }

        public string PasswordResetToken { get; set; }
        public DateTime PassworResetExpire { get; set; }
        public bool IsConfirmed { get; set; }

        public ICollection<News> News { get; set; }
        public ICollection<Ticket> AssignedTickets { get; set; }
        public ICollection<Ticket> IssuedTickets { get; set; }
        public ICollection<TicketReply> TicketReplies { get; set; }
        public ICollection<Transaction> Transactions { get; set; }



    }
}
