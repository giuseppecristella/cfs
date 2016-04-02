using System;
using System.Collections.Generic;
using System.Linq;
using Shop.Core.Domain.Orders;
using Shop.Data;

namespace Shop.Web.Mvp.UserControls
{
    public partial class UCOrdersList : System.Web.UI.UserControl
    {
        public int CustomerId { get; set; }
        public int? Count { get; set; }
        public string PageContainerName { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            lvOrders.DataSource = GetCustomerOrders(CustomerId);
            lvOrders.DataBind();
        }

        private List<Order> GetCustomerOrders(int customerId)
        {
            List<Order> orders;
            using (var ctx = new ShopDataContext())
            {
                orders = Count.HasValue ? ctx.Orders.Where(o => o.CustomerId.Equals(customerId)).Take(Count.Value).OrderByDescending(o => o.SubmissionDate).ToList() : ctx.Orders.Where(o => o.CustomerId.Equals(customerId)).OrderByDescending(o => o.SubmissionDate).ToList();
            }
            return orders;
        }
    }
}