using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web.Security;
using Ez.Newsletter.MagentoApi;
using Shop.Core.BusinessDelegate;

namespace Shop.Web.Mvp.Customers.AccountInfo
{
    public partial class Addresses : System.Web.UI.Page
    {
        private static List<CustomerAddress> _customerAddresses;
        private readonly BusinessDelegate _businessDelegate;
        public Addresses()
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
            _customerAddresses = _businessDelegate.GetCustomerAddresses(magentoUserId);
            BindCustomerAddress();
        }

        private void BindCustomerAddress()
        {
            var shippingAddress = _customerAddresses.FirstOrDefault();

            if (shippingAddress == null) return;
            txtFirstName.Text = shippingAddress.firstname;
            txtLastName.Text = shippingAddress.lastname;
            txtCity.Text = shippingAddress.city;
            txtPhone.Text = shippingAddress.telephone;
            txtStreet.Text = shippingAddress.street;
            txtZipCode.Text = shippingAddress.postcode;
        }

        protected void btnUpdateAddress_OnClick(object sender, EventArgs e)
        {
            var shippingAddress = _customerAddresses.FirstOrDefault();
            var addressShippingId = shippingAddress != null ? shippingAddress.customer_address_id : string.Empty;
            var billingAddresses = _customerAddresses.LastOrDefault();
            var billingAddressesId = billingAddresses != null ? billingAddresses.customer_address_id : string.Empty;

            BindCustomerAddressToEntity(shippingAddress);
            BindCustomerAddressToEntity(shippingAddress);

            _businessDelegate.UpdateCustomerAddresses(shippingAddress, int.Parse(addressShippingId));
            _businessDelegate.UpdateCustomerAddresses(billingAddresses, int.Parse(billingAddressesId));
        }

        private void BindCustomerAddressToEntity(CustomerAddress customerAddress)
        {
            customerAddress.firstname = txtFirstName.Text;
            customerAddress.lastname = txtLastName.Text;
            customerAddress.city = txtCity.Text;
            customerAddress.telephone = txtPhone.Text;
            customerAddress.street = txtStreet.Text;
            customerAddress.postcode = txtZipCode.Text;
        }                                                     
    }
}