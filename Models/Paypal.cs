using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewDawnWeb.Models
{
    public class Paypal
    {
        public string cmd { get; set; }
        public string business { get; set; }
        public string no_shipping { get; set; }
        public string @return { get; set; }
        public string cancel_return { get; set; }
        public string notify_url { get; set; }
        public string currency_code { get; set; }
        public string item_name { get; set; }
        public string item_quantity { get; set; }
        public string amount { get; set; }
        public string actionURL { get; set; }
        public string custom { get; set; }

        public Paypal(IConfiguration configuration)
        {
            this.cmd = "_xclick";
            this.business = configuration.GetValue<string>("business");
            this.cancel_return = configuration.GetValue<string>("cancel_return");
            this.@return = configuration.GetValue<string>("return");

            bool useProduction = configuration.GetValue<bool>("paypal_use_prod");
            if (!useProduction)
            {
                this.actionURL = configuration.GetValue<string>("paypal_test_url");
            }
            else
            {
                this.actionURL = configuration.GetValue<string>("paypal_prod_url");
            }
            // We can add parameters here, for example OrderId, CustomerId, etc....  
            this.notify_url = configuration.GetValue<string>("notify_url");
            // We can add parameters here, for example OrderId, CustomerId, etc....  
            this.currency_code = configuration.GetValue<string>("currency_code");
        }

    }
}
