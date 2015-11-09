using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web.Security;
using Ez.Newsletter.MagentoApi;
using Shop.Core;
using Shop.Core.BusinessDelegate;
using Shop.Data;
using Order = Shop.Core.Domain.Orders.Order;

namespace Shop.Web.Mvp.Customers.Dashboard
{
    public partial class Default : System.Web.UI.Page
    {
        private readonly BusinessDelegate _businessDelegate; 
        public Default()
        {
            _businessDelegate = new BusinessDelegate();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var loggedUser = Page.User.Identity.Name;
            if (IsPostBack) return;
            if (string.IsNullOrEmpty(loggedUser)) return;

            var userAspNet = Membership.GetUser(loggedUser);
            if (userAspNet == null) return;
            var magentoUserId = int.Parse(userAspNet.Comment);

            var customer = _businessDelegate.GetCustomerById(magentoUserId);
            BindCustomer(customer);

            var customerAddresses = _businessDelegate.GetCustomerAddresses(magentoUserId);
            if (customerAddresses == null || !customerAddresses.Any()) return;
            BindAddresses(customerAddresses);

            lvOrders.DataSource = GetCustomerOrders(int.Parse(customer.customer_id));
            lvOrders.DataBind();
            //_businessDelegate.GetCustomerOrders(customer.customer_id);
            //BindOrders();
        }

        private List<Order> GetCustomerOrders(int customerId)
        {
            List<Order> orders;
            using (var ctx = new ShopDataContext())
            {
                orders = ctx.Orders.Where(o => o.CustomerId.Equals(customerId)).ToList();
            }
            return orders;
        }

        private void BindCustomer(Customer customer)
        {
            lblFirstName.Text = customer.firstname;
            lblLastName.Text = customer.lastname;
            lblEMail.Text = customer.email;
        }

        private void BindAddresses(IEnumerable<CustomerAddress> customerAddresses)
        {
            var shipmentAddress = customerAddresses.First();
            lblAdrressFirstName.Text = shipmentAddress.firstname;
            lblAdrressLastName.Text = shipmentAddress.lastname;
            lblAdrressStreet.Text = shipmentAddress.street;
            lblAddressCity.Text = shipmentAddress.city;
            lblAddressZipCode.Text = shipmentAddress.postcode;
            lblAddressPhone.Text = shipmentAddress.telephone;
        }
    }
}