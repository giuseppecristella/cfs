using System;
using System.Linq;
using Microsoft.AspNet.FriendlyUrls;

namespace Shop.Web.Mvp.Admin.Orders
{
    public partial class Order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            var orderId = 0;
            if (Request.GetFriendlyUrlSegments().Any() && !int.TryParse(Request.GetFriendlyUrlSegments()[0], out orderId)) return;
            UCOrderDetail.OrderId = orderId;
        }
    }
}