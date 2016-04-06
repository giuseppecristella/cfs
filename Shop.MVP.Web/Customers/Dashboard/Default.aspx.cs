using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using Ez.Newsletter.MagentoApi;
using Shop.Core.BusinessDelegate;
using Shop.Data;

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
            Session["user"] = userAspNet;

            var magentoUserId = int.Parse(userAspNet.Comment);

            var customer = _businessDelegate.GetCustomerById(magentoUserId);
            BindCustomer(customer);

            var customerAddresses = _businessDelegate.GetCustomerAddresses(magentoUserId);
            if (customerAddresses == null || !customerAddresses.Any()) return;
            BindAddresses(customerAddresses);

            UCOrdersList.CustomerId = int.Parse(customer.customer_id);
            UCOrdersList.Count = 10;
            UCOrdersList.PageContainerName = "Customers";
            //_businessDelegate.GetCustomerOrders(customer.customer_id);
            //BindOrders();

            if (!IsNewsletterSubscribed(customer.email))
            {
                lbChangeSubscription.Text = "Iscriviti";
                ltSubscriptionState.Text = "Al momento non risulti iscritto alla newsletter. Se vuoi iscriverti clicca il pulsante 'Iscriviti'<br />";
            }
            else
            {
                lbChangeSubscription.Text = "Disattiva iscrizione";
                ltSubscriptionState.Text = "Sei iscritto alla newsletter. Se vuoi disattivare il servizio clicca il pulsante 'Disattiva iscrizione'.<br />";
            }
        }

        private bool IsNewsletterSubscribed(string userEmail)
        {
            using (var ctx = new ShopDataContext())
            {
                var subscription = ctx.Newslettersubscriptions.FirstOrDefault(n => n.Email.Equals(userEmail));
                return subscription != null && subscription.IsActive;
            }
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

        protected void lbChangeSubscription_OnClick(object sender, EventArgs e)
        {
            if (Session["user"] == null) Response.Redirect("~/Home");
            var user = Session["user"] as MembershipUser;
            if (user == null) return;
            if (lbChangeSubscription.Text == "Iscriviti")
            {
                ChangeNewsletterSubscription(user.Email, true);
                return;
            }
            ChangeNewsletterSubscription(user.Email, false);
        }

        private void ChangeNewsletterSubscription(string email, bool active)
        {
            using (var ctx = new ShopDataContext())
            {
                var subscription = ctx.Newslettersubscriptions.FirstOrDefault(n => n.Email.Equals(email));
                if (subscription == null)
                {
                    var entity = new Newslettersubscription()
                    {
                        Email = email,
                        IsActive = true
                    };
                    ctx.Set<Newslettersubscription>().Add(entity);
                    ctx.SaveChanges();
                    return;
                }
                subscription.IsActive = active;
                ctx.SaveChanges();
            }
        }
    }
}