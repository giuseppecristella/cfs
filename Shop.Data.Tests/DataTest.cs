
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml.Schema;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Core.Domain.Brands;
using Shop.Core.Domain.Categories;
using Shop.Core.Domain.OrderProducts;
using Shop.Core.Domain.Orders;


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

        [TestMethod]
        public void Should_Add_Product_To_Cart_Trought_WCF()
        {
            var request =
                (HttpWebRequest)
                    WebRequest.Create("http://localhost:4992/WCFService/CatalogDataService.svc/AddProductToSessionCart");
            request.Method = "POST";
            request.ContentType = @"Application/json";
            string postData = @"[{\""name\"": \""s\""}]";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            // Set the ContentType property of the WebRequest.
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;
            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();
            // Get the response.
            WebResponse response = request.GetResponse();



            //var datacontractSerializer = new DataContractJsonSerializer(typeof(ProductCart));
            //var productCart = new ProductCart { Name = "giuseppe" };

            //using (var memoryStream = new MemoryStream())
            //{
            //    using (var reader = new StreamReader(memoryStream))
            //    {
            //        datacontractSerializer.WriteObject(memoryStream, productCart);
            //        memoryStream.Position = 0;

            //    }
            //}
        }

        [TestMethod]
        public void ShouldAddOrderWithProducts()
        {
            //using (var ctx = new ShopDataContext())
            //{
            //    var orderEntity = new Order
            //    {
            //        CustomerFirstName = "Giuseppe",
            //        CustomerSecondName = "Cristella",
            //        CustomerAddress = "Via Puccini",
            //        OrderStatus = "Progress",
            //        PaymentType = "PayPal",
            //        SubmissionDate = DateTime.Now,
            //        Total = 100
            //    };
            //    var products = new List<OrderProduct>
            //    {
            //        new OrderProduct
            //        {
            //            Name = "Ciabatta",
            //            UnitPrice = 1,
            //            Qty = 2,
            //            TotalPrice = 10
            //        }
            //    };

            //    orderEntity.OrderProducts = products;
            //    ctx.Set<Order>().Add(orderEntity);
            //    var saveResult = ctx.SaveChanges();
            //}
        }

        [TestMethod]
        public void ShoulCreateOrderWithOrderProducts()
        {
            var order = new Order
            {
                MagentoOrderId = 1,
                SubmissionDate = DateTime.Now,
                CustomerAddress = "Via Puccini, 17",
                CustomerFirstName = "Giuseppe",
                CustomerId = 1,
                CustomerSecondName = "Cristella",
                OrderStatus = "Submitted",
                PaymentType = "Credit Card",
                Total = 50,
                SubTotal = 44,
                Shipment = 6
            };

            order.OrderProducts = new List<OrderProduct>
            {
                new OrderProduct
                {
                    Name = "Dummy product 1",
                    Qty = 3,
                    UnitPrice = 10,
                    TotalPrice = 300,
                    Size = 39
                },
                new OrderProduct
                {
                    Name = "Dummy product 2",
                    Qty = 1,
                    UnitPrice = 70,
                    TotalPrice = 70,
                    Size = 39
                },
                new OrderProduct
                {
                    Name = "Dummy product 2",
                    Qty = 1,
                    UnitPrice = 70,
                    TotalPrice = 70,
                    Size = 36
                }
            };

            using (var ctx = new ShopDataContext())
            {
                ctx.Set<Order>().Add(order);
                var saveResult = ctx.SaveChanges();
            }

        }

        [TestMethod]
        public void ShouldSaveCategoryWithBrands()
        {
            using (var ctx = new ShopDataContext())
            {
                var brands =  ctx.Set<Shop.Core.Domain.Categories.Category>().FirstOrDefault(c => c.Id.Equals(1));
                var a = ctx.Set<Category>().ToList();
            }

            var category = new Category
            {
                Name = "Sneakers",
                Brands = new List<Brand>
                {
                     new Brand{ Name = "nike"},
                     new Brand{ Name = "superga"}
                }
            };
            using (var ctx = new ShopDataContext())
            {
                ctx.Set<Category>().Add(category);
                var saveResult = ctx.SaveChanges();
            }
        }
    }
}
