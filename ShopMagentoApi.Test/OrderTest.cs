using MagentoComunication.Enum;
using MagentoRepository.Connection;
using MagentoRepository.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Core.Cache;

namespace ShopMagentoApi.Test
{
    [TestClass]
    public class OrderTest
    {
        [TestInitialize]
        public void TestInitialize()
        {
            MagentoConnection.Instance.Url = "http://www.calzafacileshop.com/api/xmlrpc";
            MagentoConnection.Instance.UserId = "ws_user";
            MagentoConnection.Instance.Password = "123456";
        }

        [TestMethod]
        public void Should_Create_Order()
        {
            var repository = new RepositoryService(MagentoConnection.Instance, new FakeCacheManager());
            var orderInfo = repository.CreateOrder(79);
            Assert.IsTrue(orderInfo > 0);
        }

        [TestMethod]
        public void Get_Order_Info_Test()
        {
            var repository = new RepositoryService(MagentoConnection.Instance, new FakeCacheManager());
            var orderInfo = repository.GetOrderInfos(1);
            // Assert

        }

        [TestMethod]
        public void Shoul_Set_Order_Status()
        {
            var repository = new RepositoryService(MagentoConnection.Instance, new FakeCacheManager());
            var actual = repository.SetOrderStatus(1, OrderStatusType.Canceled);
            Assert.IsTrue(actual);
        }

    }
}
