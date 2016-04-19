using System.IO;
using System.Net;
using System.Net.Mail;
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
                MailTo = "giuseppe.cristella@libero.it",
                MailFrom = "info@calzafacile.com",
                MailSubject = "Conferma ordine",
                MailTemplate = @"D:\Progetti\Siti\Calzafacile\Shop.MVP.Web\MailTemplates\Business\newsletter.html",

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

        [TestMethod]
        public void ShouldMoveCssInlineFromMailTemplate()
        {
            //string htmlSource = File.ReadAllText(@"D:\Progetti\Siti\Calzafacile\Shop.MVP.Web\MailTemplates\Business\order.html"); 
            //var pm = new PreMailer.Net.PreMailer(htmlSource);
            //var a = pm.MoveCssInline();

            var mailManager = new MailManager()
            {
                MailTo = "giuseppe.cristella@libero.it",
                MailFrom = "info@calzafacile.com",
                MailSubject = "Conferma ordine",
                MailTemplate = @"D:\Progetti\Siti\Calzafacile\Shop.MVP.Web\MailTemplates\Business\order.html",

                //MailParameters = new Hashtable
                //{
                //    {"##CouponeCode##", "GY2DE-NQPQQ-RV"},
                //},
                DisplayName = "Calzafacile fn"
            };
            mailManager.SendMail();
        }

    }
}
