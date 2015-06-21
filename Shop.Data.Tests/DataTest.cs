 
using System;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
 

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
    }
}
