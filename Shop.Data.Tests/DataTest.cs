
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Xml.Schema;
using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace Shop.Data.Tests
{
    [TestClass]
    public class DataTest
    {
        [TestMethod]
        public void TestMethod1()
        {

            //Database.SetInitializer<ShopObjectContext>(null);
            //var ctx = new ShopObjectContext("Test");
            //string result = ctx.CreateDatabaseScript();

            //Console.Write(result);

        }

        [TestMethod]
        public void ShouldCreatePromotion()
        {
            using (var ctx = new ShopDataContext())
            {
                var entity = new Promotion()
                {
                    Name = "LancioSito",
                    Description = "Promozione lancio, regalo infradito"
                };

                ctx.Set<Promotion>().Add(entity);
                ctx.SaveChanges();
            }
        }


        [TestMethod]
        public void ShoulCrateNewsletterSubscriptionWithAndAssignPromoCode()
        {
            using (var ctx = new ShopDataContext())
            {
                var entity = new Newslettersubscription()
                {
                    Email = "test03@test.it"
                };

                // Check codice già assegnato a quell'indirizzo per quella promo
                var assignedCodeForUserSubscriptionAndPromotion =
                    ctx.PromotionCodes.Where(pc => pc.Newslettersubscription.Email.Equals(entity.Email) && pc.PromotionId.Equals(1));
                Assert.IsTrue(assignedCodeForUserSubscriptionAndPromotion != null);

                var firstNotAssignedCode = ctx.PromotionCodes.FirstOrDefault(pc => pc.Newslettersubscription == null);
                firstNotAssignedCode.IsAssigned = true;
                firstNotAssignedCode.NewslettersubscriptionEmail = entity.Email;

                entity.PromotionCodes.Add(firstNotAssignedCode);

                Assert.AreEqual(entity.PromotionCodes.Count, 1);

                ctx.Set<Newslettersubscription>().Add(entity);
                var saveResult = ctx.SaveChanges();

                //Assert.IsTrue(saveResult.Equals(0));
            }
        }

     }
}
