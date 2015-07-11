using System;
using System.Collections;
using System.Collections.Specialized;
using System.Net;
using System.Net.Mail;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Core.Utility;

namespace Shop.Data.Tests.Other_Tests
{
    [TestClass]
    public class MailManagerTest
    {
        [TestMethod]
        public void SholdSendEmail()
        {
            var mailManager = new MailManager()
            {
                MailTo = "gcristella@live.it", //"ins-02fuodzi@isnotspam.com",
                MailFrom = "info@calzafacile.com",
                MailSubject = "Che belle...che gratis, le infradito che ti regala Calzafacile!",
                MailTemplate = @"C:\Progetti\cfs\Shop.MVP.Web\MailTemplates\PromoStart\PromoStart.html",

                //MailParameters = new Hashtable
                //{
                //    {"##CouponeCode##", "GY2DE-NQPQQ-RV"},
                //},
                DisplayName = "Calzafacile fn"
            };
            mailManager.SendMail();
        }

        [TestMethod]
        public void ShouldSendEmailThroughSmtpClient()
        {
            MailMessage mailMessage = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();


            mailMessage.Subject = "Promozione infradito";
            //    mailMessage.Sender = new MailAddress("web@calzafacile.com");
            mailMessage.IsBodyHtml = false;
            mailMessage.From = new MailAddress("web@calzafacile.com");

            mailMessage.To.Add(new MailAddress("gcristella@live.it"));
            mailMessage.Body = "Nel mezzo del cammin di nostra vita mi ritrovai in una selva oscura.";

            mailMessage.Headers.Add("X-Company", "Calzafacile srl");
            mailMessage.Headers.Add("X-Location", "Laterza");

            smtpClient.Send(mailMessage);

        }

        [TestMethod]
        public void ShouldSendEmailThroughGmail()
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("giuseppecristella76@gmail.com", "cassano99"),
                EnableSsl = true
            };
            client.Send("giuseppecristella76@gmail.com", "gcristella@live.it", "invio tramite gmail", "invio tramite smtp gmail");
            
        }

    }
}
