using System;
using System.Collections;
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
                MailTo = "giuseppecristella76@gmail.com",
                MailFrom = "info@calzafacile.com",
                MailSubject = "Che belle...che gratis, le infradito che ti regala Calzafacile!",
                MailTemplate = @"C:\Progetti\cfs\Shop.MVP.Web\MailTemplates\PromoStart\PromoStart.html",
                MailParameters = new Hashtable
                {
                    {"##CouponeCode##", "GY2DE-NQPQQ-RV"},
                },
                DisplayName = "Calzafacile"
            };
            mailManager.SendMail();
        }
    }
}
