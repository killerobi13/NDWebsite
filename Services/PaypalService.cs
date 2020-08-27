using Microsoft.Extensions.Configuration;
using NewDawnWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewDawnWeb.Services
{
    public class PaypalService
    {

        private SqlDbContext sqlDbContext { get; set; }
        private IConfiguration config { get; set; }
        public PaypalService(SqlDbContext sqlDbContext, IConfiguration config)
        {
            this.config = config;
            this.sqlDbContext = sqlDbContext;
 
        }

      
        public void ProcessTransaction(string transactionRequest)
        {
            transactionRequest= System.Web.HttpUtility.UrlDecode(transactionRequest);
            var transDic = ParseTransaction(transactionRequest);
            string username = transDic["custom"];
            bool correctTransaction = true;
            User user = null;

            Dictionary<int, int> amountCoins = new Dictionary<int, int>()
            {
                { 10,1000 },
                { 20, 2300 },
                { 30, 3500 },
                { 50, 6000 },
                {75, 9000 },
                {100, 12000 }

            };
          
                try
                {
                    if (ValidateTransaction(transDic))
                    {
                        Console.WriteLine("Passed validation");
                        LogTransaction(transDic, correctTransaction, user);
                        user = sqlDbContext.Users.Single(t => t.Username == username);
                        user.Coins += amountCoins[Convert.ToInt32(Double.Parse(transDic["mc_gross"]))];
                        sqlDbContext.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        sqlDbContext.SaveChanges();

                    }
                    else
                    {
                        correctTransaction = false; 
                    }
                }
                catch(Exception e)
                {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(transactionRequest);
                    correctTransaction = false; 
                }
       

           
        }

        public void LogTransaction(Dictionary<string, string> keyValues, bool valid, User u)
        {
            Transaction t = new Transaction();
            t.Currency = keyValues["mc_currency"];
            t.Amount = Double.Parse(keyValues["mc_gross"]);
            t.Date = DateTime.Now;
            t.Email = keyValues["payer_email"];
            t.User = u;
            t.Valid = valid;

            sqlDbContext.Transactions.Add(t);
            sqlDbContext.SaveChanges();
        }
        public bool ValidateTransaction(Dictionary<string,string> keyValues)
        {
            return keyValues["payment_status"] == "Completed";
        }
        public Dictionary<string,string> ParseTransaction(string str)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            var items = str.Split('&');
            foreach( var t in items)
            {
                var keyValue = t.Split('=');

                if (keyValue.Length >= 2)
                    dictionary.Add(keyValue[0], keyValue[1]);
            }

            return dictionary;
        }
 
    }
}
