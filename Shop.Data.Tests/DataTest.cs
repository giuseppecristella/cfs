
using System;
using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Core.Domain.Messages;
using Shop.Core.Domain.Promotions;


namespace Shop.Data.Tests
{
    [TestClass]
    public class DataTest
    {
        [TestMethod]
        public void TestMethod1()
        {

            Database.SetInitializer<ShopObjectContext>(null);
            var ctx = new ShopObjectContext("Test");
            string result = ctx.CreateDatabaseScript();

            Console.Write(result);

        }

        [TestMethod]
        public void TestMethod2()
        {
            using (var ctx = new ShopObjectContext("ShopContext"))
            {
                var entity = new NewsLetterSubscription()
                {
                    Email = "giuseppe.cristella@libero.it",
                    PromotionCodes = new List<PromotionCode>()
                    {
                        new PromotionCode()
                        {
                            Code = "000001",
                            NewsLetterSubscriptionId = 1
                        }
                    }
                };

                ctx.Set<NewsLetterSubscription>().Add(entity);
                ctx.SaveChanges();
            }
        }
    }
}
