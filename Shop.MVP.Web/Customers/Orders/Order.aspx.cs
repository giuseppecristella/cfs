using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.FriendlyUrls;
using Shop.Data;
using OrderProduct = Shop.Core.Domain.OrderProducts.OrderProduct;

namespace Shop.Web.Mvp.Customers.Orders
{
    public partial class Order : System.Web.UI.Page
    {
        public static Core.Domain.Orders.Order OrderViewModel { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            var orderId = 0;
            if (Request.GetFriendlyUrlSegments().Any() && !int.TryParse(Request.GetFriendlyUrlSegments()[0], out orderId)) return;

            lvOrderProducts.DataSource = GetOrderProducts(orderId);
            lvOrderProducts.DataBind();

            OrderViewModel = GetOrderHeader(orderId);
        }

         

        private List<OrderProduct> GetOrderProducts(int orderId)
        {
            List<OrderProduct> orderProducts;
            using (var ctx = new ShopDataContext())
            {
                orderProducts = ctx.OrderProducts.Where(p => p.OrderId.Equals(orderId)).ToList();
            }
            return orderProducts;
        }

        private Shop.Core.Domain.Orders.Order GetOrderHeader(int orderId)
        {
            Shop.Core.Domain.Orders.Order order;
            using (var ctx = new ShopDataContext())
            {
                order = ctx.Orders.FirstOrDefault(o => o.Id.Equals(orderId));
            }
            return order;
        }
    }
}