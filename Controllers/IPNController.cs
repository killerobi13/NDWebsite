using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NewDawnWeb.Services;

namespace NewDawnWeb.Controllers
{
    [Route("IPN")]
    public class IPNController : Controller
    {
		private PaypalService paypalService;
		public IPNController(PaypalService paypalService)
		{
			this.paypalService = paypalService;
		}
		[HttpPost]
		public async void Receive()
		{
			Console.WriteLine("ReceivedPayment");
			String s = String.Empty;
			using (StreamReader reader = new StreamReader(Request.Body, Encoding.ASCII))
			{
				s = await reader.ReadToEndAsync();
			}
			//Fire and forget verification task
			VerifyTask(s);
		}

		private void VerifyTask(string strRequest)
		{
			string verificationResponse = string.Empty;

			try
			{
				var verificationRequest = WebRequest.Create("https://www.paypal.com/cgi-bin/webscr");

				//Set values for the verification request
				verificationRequest.Method = "POST";
				verificationRequest.ContentType = "application/x-www-form-urlencoded";
 
				//Add cmd=_notify-validate to the payload
				strRequest = "cmd=_notify-validate&" + strRequest;
				verificationRequest.ContentLength = strRequest.Length;

				//Attach payload to the verification request
				using (StreamWriter writer = new StreamWriter(verificationRequest.GetRequestStream(), Encoding.ASCII))
				{
					writer.Write("HTTP/1.0 200 OK");
					writer.Write(Environment.NewLine);
					writer.Write("Content-Type: text/plain; charset=UTF-8");
					writer.Write(Environment.NewLine);
					writer.Write("Content-Length: " + 0);
					writer.Write(Environment.NewLine);
				}
				using (StreamWriter writer = new StreamWriter(verificationRequest.GetRequestStream(), Encoding.ASCII))
				{
					writer.Write(strRequest);
				}

				

				//Send the request to PayPal and get the response
				using (StreamReader reader = new StreamReader(verificationRequest.GetResponse().GetResponseStream()))
				{
					verificationResponse = reader.ReadToEnd();
				}
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception.StackTrace);
			}

			ProcessVerificationResponse(strRequest,verificationResponse);
		}


	 

		private void ProcessVerificationResponse(string request,string verificationResponse)
		{
 
			if (verificationResponse.Equals("VERIFIED"))
			{
				Console.WriteLine("VERIFIED");
				paypalService.ProcessTransaction(request);
			}
			else
			{
				paypalService.LogTransaction(paypalService.ParseTransaction(request), false, null);
			}
			
		}
	}
}