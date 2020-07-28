using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;
using RestSharp;
using RestSharp.Authenticators;

namespace GrocedyAPI.Helpers
{
    public class EmailHelper : MailMessage
    {
        private bool _isInitValid = true;

        public static string DefaultFrom { get; set; }
        public static string DefaultTo { get; set; }

        /// <summary>
        /// Instantiates a MailMessage object using default From and To
        /// </summary>
        /// <param name="Subject">Email subject line</param>
        /// <param name="Body">Email body that can contain HTML tags</param>
        public EmailHelper(string Subject, string Body)
        {
            EmailInit(DefaultFrom, DefaultTo, Subject, Body);
        }

        /// <summary>
        /// Instantiates a MailMessage object
        /// </summary>
        /// <param name="from">A valid email address. If null it will use DefaultFrom</param>
        /// <param name="to">A comma separated list of valid email addresses. If null it will use DefaultTo</param>
        /// <param name="Subject">Email subject line</param>
        /// <param name="Body">Email body that can contain HTML tags</param>
        public EmailHelper(string from, string to, string Subject, string Body)
        {
            if (string.IsNullOrEmpty(from))
                from = DefaultFrom;
            if (string.IsNullOrEmpty(to))
                to = DefaultTo;
            EmailInit(from, to, Subject, Body);
        }

        /// <summary>
        /// Sends the configured email
        /// </summary>
        /// <returns>Returns true if the operation is successful</returns>
        public bool Send()
        {
            bool result = _isInitValid;
            if (_isInitValid)
            {
                try
                {
                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Send(this);
                }
                catch (Exception)
                {
                    //  Elmah.ErrorSignal.FromCurrentContext().Raise(ex);

                    result = false;
                }
            }
            return result;
        }

        public bool SendElastic()
        {
            bool result = _isInitValid;
            if (_isInitValid)
            {
                try
                {

                    SmtpClient SmtpServer = new SmtpClient("smtp.elasticemail.com");
                    SmtpServer.Port = 2525;
                    //4403074946202EA4F2C2E135AF40D6F4574B273CB100DACDCD3A7CFFD5CFDC18D8B1E01B37FC515F1DA223B1073EFB00

                    SmtpServer.Credentials = new System.Net.NetworkCredential("sylendra92@gmail.com", "7A7F02065AD332D9CA230095105474725FFF");
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(this);
                }
                catch (Exception ex)
                {
                    //  Elmah.ErrorSignal.FromCurrentContext().Raise(ex);

                    result = false;
                }
            }
            return result;
        }


        private void EmailInit(string From, string To, string Subject, string Body)
            {
            try
            {
             base.   From = new MailAddress(From);
                foreach (string emailTo in To.Split(','))
                {
                    base.To.Add(new MailAddress(emailTo.Trim()));
                }
                base.Subject = Subject;
                base.Body = Body;
                base.IsBodyHtml = true;
                
            }
            catch (Exception ex)
            {
                // Elmah.ErrorSignal.FromCurrentContext().Raise(ex);

                _isInitValid = false;
            }
        }

        /// <summary>
        /// Validates an email address
        /// </summary>
        /// <param name="email">The Email address to validate</param>
        /// <returns></returns>
        public static bool IsValidEmail(string email)
        {
            bool result;

            try
            {
                var addr = new MailAddress(email);
                result = true;
            }
            catch (Exception)
            {
                //  Elmah.ErrorSignal.FromCurrentContext().Raise(ex);

                result = false;
            }

            return result;
        }

     public static IRestResponse SendSimpleMessage(string to , string subject,string body)
        {
            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3");
            client.Authenticator =
            new HttpBasicAuthenticator("api",
                                       "4c958acaf335f53c714f6055e420d9df-65b08458-430e7698");
            RestRequest request = new RestRequest();
            request.AddParameter("domain", "sandboxea49d485f7894f77a9589fab048301a4.mailgun.org", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "Mailgun Sandbox <postmaster@sandboxea49d485f7894f77a9589fab048301a4.mailgun.org>");
            request.AddParameter("to", to);
            request.AddParameter("subject", subject);
            request.AddParameter("text", body);
            request.Method = Method.POST;
            return client.Execute(request);
        }   

        // You can see a record of this email in your logs: https://app.mailgun.com/app/logs.

        // You can send up to 300 emails/day from this sandbox server.
        // Next, you should add your own domain so you can send 10000 emails/month for free.

    }
}