using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewDawnWeb.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string HtmlDescription { get; set; }
        public string? ShortDescription { get; set; }

        public int Type { get; set; }

        public DateTime PublishedDate { get; set; }

        public User Publisher { get; set; }
    }
}
