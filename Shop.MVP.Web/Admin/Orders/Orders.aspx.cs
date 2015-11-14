using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shop.Data;
using Telerik.Web.UI;

namespace Shop.Web.Mvp.Admin.Orders
{
    public partial class Orders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void rgAdminOrders_OnNeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            List<Core.Domain.Orders.Order> orders;
            using (var ctx = new ShopDataContext())
            {
                orders = ctx.Orders.ToList();
            }

            rgAdminOrders.DataSource = orders;
        }
    }
}