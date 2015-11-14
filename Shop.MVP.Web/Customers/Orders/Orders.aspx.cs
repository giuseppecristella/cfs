using System;
using System.Web.Security;
using Shop.Core.BusinessDelegate;

namespace Shop.Web.Mvp.Customers.Orders
{
    public partial class Orders : System.Web.UI.Page
    {
        private readonly BusinessDelegate _businessDelegate;
        public Orders()
        {
            _businessDelegate = new BusinessDelegate();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var loggedUser = "gctest11";//Page.User.Identity.Name;
            if (IsPostBack) return;
            if (string.IsNullOrEmpty(loggedUser)) return;

            var userAspNet = Membership.GetUser(loggedUser);
            if (userAspNet == null) return;
            var magentoUserId = int.Parse(userAspNet.Comment);

            var customer = _businessDelegate.GetCustomerById(magentoUserId);
            UCOrdersList.CustomerId = int.Parse(customer.customer_id);
            UCOrdersList.PageContainerName = "Customers";
        }
    }
}