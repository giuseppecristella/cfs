using System.Collections.Generic;
using Ez.Newsletter.MagentoApi;
using MagentoBusinessApi.Test;
using MagentoComunication.Helpers;
using MagentoRepository.Connection;
using MagentoRepository.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Core;
using Shop.Core.BusinessDelegate;
using Shop.Core.Cache;
using CookComputing.XmlRpc;


namespace ShopMagentoApi.Test
{
    [TestClass]
    public class CartTest
    {
        private static readonly int testCartId = 482;
        private static readonly FakeCacheManager FakeCacheManager = new FakeCacheManager();

        [TestInitialize]
        public void TestInitialize()
        {
            MagentoConnection.Instance.Url = "http://www.calzafacileshop.com/api/xmlrpc";
            MagentoConnection.Instance.UserId = "ws_user";
            MagentoConnection.Instance.Password = "123456";
            MagentoConnection.Instance.CacheManager = FakeCacheManager;
            MagentoConnection.Instance.Login();
        }

        [TestMethod]
        public void Should_Add_Key_To_Session_Cache()
        {
            var cache = new AspNetCacheManagerTest();
            cache.Add("test_key_string", "stringa di prova");
            var value = cache.Get<string>("test_key_string");
            Assert.AreEqual(value, "stringa di prova");
        }

        /// <summary>
        /// Integration Test: viene testato il processo di aggiunta prodotti
        /// al carrello, usando come meccanismo di cache quello effettivo
        /// che sarà utilizzato nell'applicazione ossia la session cache asp.net
        /// </summary>
        [TestMethod]
        public void Add_Some_Products_To_Cart()
        {
            //var cache = new AspNetCacheManagerTest();
            //var product = GetProductById("173");

            //CartHelper.CacheManager = new AspNetCacheManagerTest();
            //CartHelper.AddProductToCartAndUpdateCache(product);
            //CartHelper.AddProductToCartAndUpdateCache(product);

            //var cartFromCache = cache.Get<Cart>("Cart");
            //Assert.AreEqual(cartFromCache.Products.Count(), 1);

            //product = GetProductById("179");
            //CartHelper.AddProductToCartAndUpdateCache(product);

            //cartFromCache = cache.Get<Cart>("Cart");
            //Assert.AreEqual(cartFromCache.Products.Count(), 2);
        }

        [TestMethod]
        public void Update_Product_Qty_Of_Items_In_Cart()
        {
            //var cache = new AspNetCacheManagerTest();
            //var product = GetProductById("173");

            //CartHelper.CacheManager = new AspNetCacheManagerTest();
            //CartHelper.AddProductToCartAndUpdateCache(product);
            //product = GetProductById("179");
            //CartHelper.AddProductToCartAndUpdateCache(product);

            //var cartFromCache = cache.Get<Cart>("Cart");
            //Assert.AreEqual(cartFromCache.Products.Count(), 2);

            //Assert.IsNull(cartFromCache.Products.First(p => p.product_id == "173").qty);
            //var itemToUpdate = cartFromCache.Products.First(p => p.product_id == "173");
            //itemToUpdate.qty = "100";
            //Assert.AreEqual(cartFromCache.Products.First(p => p.product_id == "173").qty, "100");
        }

        [TestMethod]
        public void Should_Delete_Products_From_Cart()
        {
            //var productsToDelete = new List<Product>();

            //// Creo un carrello con 2 prodotti
            //var cache = new AspNetCacheManagerTest();
            //var product = GetProductById("173");
            //productsToDelete.Add(product);

            //CartHelper.CacheManager = new AspNetCacheManagerTest();
            //CartHelper.AddProductToCartAndUpdateCache(product);
            //product = GetProductById("179");
            ////productsToDelete.Add(product);
            //CartHelper.AddProductToCartAndUpdateCache(product);

            //var cartFromCache = cache.Get<Cart>("Cart");
            //cartFromCache.DeleteProducts(productsToDelete);
            //Assert.AreEqual(cartFromCache.Products.Count(), 1);
            //Assert.AreEqual(cartFromCache.Products.First().product_id, "179");
        }

        [TestMethod]
        public void Should_Get_All_Shipping_Methods()
        {
            var repository = new RepositoryService(MagentoConnection.Instance, FakeCacheManager);

            repository.AddShippingMethodToCart(149, "flatrate_flatrate");
            repository.GetShippingMethods(148);
        }

        /// <summary>
        /// 
        /// La nuova versione di magento restituiva un errore nella chiamata al metodo
        /// Cart.AddProduct sostituito il file php in:
        /// /public_html/app/code/core/Mage/Checkout/Model/Cart/Product
        /// </summary>
        [TestMethod]
        public void Should_Create_Cart_In_Magento()
        {
            var customerId = 1;
            var repository = new RepositoryService(MagentoConnection.Instance, FakeCacheManager);
            var cart = repository.CreateCart();
            //var customer = repository.GetCustomerById(customerId);
            var customer = new Customer
            {
                firstname = "Giuseppe",
                lastname = "Cristella",
                email = "g@cristella.it",
                mode = "register",
                customer_id = "1"
            };
            //customer = repository.GetCustomerById(customerId);
            customer.mode = "register";
            var result = repository.AssociateCustomerToCart(cart, customer);
            var customerAddresses = repository.GetCustomerAddresses(customerId);

            customerAddresses[0].mode = "billing";
            //customerAddresses[1].mode = "shipping";

            var areCustomerAddressesAddedToCart = repository.AddCustomerAddressesToCart(cart, customerAddresses);

            var productId = "118";
            var product = GetProductById(productId);
            var products = new List<Product>();
            products.Add(product);
            var p = new Product
            {
                product_id = "1",
                sku = "ddd",
                qty = "3"
            };
            repository.AddProductToCart(cart, p);

            var paymentMethods = repository.GetPaymentMethods(cart);

            var qty = repository.GetProductsByCategoryId("30");
        }

        [TestMethod]
        public void Should_Associate_Customer_To_Cart()
        {
            var key = ConfigurationHelper.CacheKeyNames;

            //var repository = new RepositoryService(MagentoConnection.Instance, FakeCacheManager);
            //var cartId = repository.CheckOut();
            var repository = new RepositoryService(MagentoConnection.Instance, FakeCacheManager);
            var customer = repository.GetCustomerById(33);
            customer.mode = "register";
            var result = repository.AssociateCustomerToCart(testCartId, customer);

            Assert.IsTrue(result, "Non è stato possibile associare un carrello valido ad un utente esistente");
        }

        [TestMethod]
        public void Should_Get_Payment_Methods()
        {
            var repository = new RepositoryService(MagentoConnection.Instance, FakeCacheManager);
            var paymentMethods = repository.GetPaymentMethods(166);
        }

        [TestMethod]
        public void Should_Create_Checkout()
        {
            
            var customerId = 1;
            var repository = new RepositoryService(MagentoConnection.Instance, FakeCacheManager);
            //var customer = repository.GetCustomerById(customerId);

            var customer = new Customer
            {
                firstname = "Giuseppe",
                lastname = "Cristella",
                email = "g@cristella.it",
                mode = "register",
                customer_id = "1"
            };

            var businessDelegateCart = new BusinessDelegate();

            var cartId = 168;//businessDelegateCart.CreateCart();

            var customerAddresses = new List<CustomerAddress>
            {
                new CustomerAddress
                {
                    firstname = "Giuseppe", 
                    lastname = "Cristella",
                    city = "Laterza",
                    street = "via puccini",
                    postcode = "123",
                    region = "ita",
                    telephone = "3497154012",
                    country_id = "2",
                    mode = "shipping"
                },
                new CustomerAddress
                {
                    firstname = "Giuseppe", 
                    lastname = "Cristella",
                    city = "Laterza",
                    street = "via puccini",
                    postcode = "123",
                    region = "ita",
                    telephone = "3497154012",
                    country_id = "2",
                    mode = "billing"
                }
            };
            var products = new List<Product>();
            var p = new Product
            {
                product_id = "55",
                sku = "product1",
                qty = "1"
            };
            products.Add(p);
            p = new Product
            {
                product_id = "55",
                sku = "product2",
                qty = "1"
            };
            products.Add(p);

            var paymentMethod = new PaymentMethod();

            businessDelegateCart.PrepareCartForOrder(cartId, customer, customerAddresses, products, "shippingMethodDummy", paymentMethod);
            var orderInfo = repository.CreateOrder(cartId);
            
            // Crea Ordine in SQL
        }

        #region Private Methods

        private Product GetProductById(string productId)
        {

            var filterParameters = new XmlRpcStruct();
            var filterOperator = new XmlRpcStruct { { "eq", productId } };
            filterParameters.Add("product_id", filterOperator);
            var products = Product.List(MagentoConnection.Instance.Url, MagentoConnection.Instance.SessionId, new object[] { filterParameters });
            return products[0];
        }
        #endregion
    }
}
