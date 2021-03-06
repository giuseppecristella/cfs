﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using Shop.Core.Domain.OrderProducts;
using Shop.Core.Domain.Orders;
using Shop.Data;

namespace Shop.Web.Mvp.UserControls
{
    public partial class UCOrderDetail : UserControl
    {
        public static Order OrderViewModel { get; set; }
        public int OrderId { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            lvOrderProducts.DataSource = GetOrderProducts(OrderId);
            lvOrderProducts.DataBind();
            OrderViewModel = GetOrderHeader(OrderId);
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

        private Order GetOrderHeader(int orderId)
        {
            Order order;
            using (var ctx = new ShopDataContext())
            {
                order = ctx.Orders.FirstOrDefault(o => o.Id.Equals(orderId));
            }
            return order;
        }
    }
}