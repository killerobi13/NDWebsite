using System;
using System.Net.Mail;
using System.Threading.Tasks;

namespace NewDawnWeb.Services
{
    public class EmailService
    {
        public async void SendAsync(string destionationUser,string subject, string content)
        {

            var result = Task.Factory.StartNew(() =>
            {
                try
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient(@"SSL0.OVH.NET");

                    mail.From = new MailAddress(@"support@newdawn9d.fun");
                    mail.To.Add(destionationUser);
                    mail.Subject = subject;
                    mail.Body = content;
                    SmtpServer.UseDefaultCredentials = false;
                    mail.IsBodyHtml = true;

                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential(@"support@newdawn9d.fun", @"!Floare18");
                    SmtpServer.Send(mail);

                }
                catch
                {

                }
            }

            );

            await result;


        }
    }
}
