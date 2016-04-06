using System;
using System.Globalization;
using System.Web.Security;
using System.Web.UI.WebControls;
using Ez.Newsletter.MagentoApi;
using Shop.Core.BusinessDelegate;
using Shop.Core.Utility;
using Shop.Data;
using Shop.Web.Mvp.Checkout;

namespace Shop.Web.Mvp.Login
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

        }
        protected void OnLoginError(object sender, EventArgs e)
        {
            var currentUser = Membership.GetUser(Login.UserName);
            var lblFailureText = Login.FindControl("lblFailureText") as Literal;
            if (lblFailureText == null) return;

            if (currentUser == null)
            {
                lblFailureText.Text = Resources.Resources.UnregisteredUser_Error;
            }
            else
            {
                if (!currentUser.IsApproved) Login.FailureText = Resources.Resources.NotApprovedUser_Error;
                else if (currentUser.IsLockedOut) Login.FailureText = Resources.Resources.LockedUser_Error;
                else lblFailureText.Text = Resources.Resources.InvalidPassword_Error;
            }
        }

        protected void OnLoggedIn(object sender, EventArgs e)
        {
            Response.Redirect("~/Customers/Dashboard/");
        }

        protected void cuwUser_OnCreatedUser(object sender, EventArgs e)
        {
            var membershipUser = Membership.GetUser(cuwUser.UserName);
            if (membershipUser == null) return;
            try
            {
                Roles.AddUserToRole(cuwUser.UserName, "User");
                // TODO: Check errore creazione utente lato Magento, rollback e cancellazione utente asp.net 
                var magentoCustomerId = CreateMagentoCustomer();

                // Salvo nel campo 'comment' dell'oggetto User di MembershipProvider il customer CustomerId di Magento
                membershipUser.Comment = magentoCustomerId;
                Membership.UpdateUser(membershipUser);

                if (cbNewsletterSubscription.Checked) SubscriveSignedCustomerToNewsLetter(txtEmail.Text);
                //SendNotificationEmailToSignedCustomer(membershipUser.UserName, cuwUser.Password);
                CreateMagentoCustomerAddress(AddressType.Billing, magentoCustomerId);
                CreateMagentoCustomerAddress(AddressType.Shipping, magentoCustomerId);
            }
            catch (Exception ex)
            {
                // log 

                //divErr.Visible = true;
                //lblErr.Text = "Attenzione: si è verificato un'errore nella creazione dell'account. Si prega di ripetere l'operazione.";
                // Cancello l'utente dal nostro db perchè non è stato creato in magento
                Membership.DeleteUser(membershipUser.UserName);
            }
        }

        private void SubscriveSignedCustomerToNewsLetter(string email)
        {
            using (var ctx = new ShopDataContext())
            {
                var entity = new Newslettersubscription()
                {
                    Email = email,
                    IsActive = true
                };
                ctx.Set<Newslettersubscription>().Add(entity);
                var saveResult = ctx.SaveChanges();
            }
        }

        private void SendNotificationEmailToSignedCustomer(string userName, string password)
        {
            var mailManager = new MailManager()
            {
                MailTo = txtEmail.Text,
                MailFrom = "info@calzafacile.com",
                MailSubject = "Benvenuto in Calzafacile!",
                MailTemplate = string.Format("{0}AccountCreation.html", Server.MapPath("~/MailTemplates/Subscription/")),

                //MailParameters = new Hashtable
                //{
                //    {"##CouponeCode##", "GY2DE-NQPQQ-RV"},
                //},
                DisplayName = "Calzafacile"
            };
            mailManager.SendMail();
        }

        private void CreateMagentoCustomerAddress(AddressType type, string customerId)
        {
            int id;
            if (!int.TryParse(customerId, out id)) return;
            var customerAddress = new CustomerAddress
            {
                firstname = txtFirstName.Text,
                lastname = txtLastName.Text,
                region = txtCity.Text,
                street = txtStreet.Text,
                telephone = txtPhone.Text,
                postcode = txtZipCode.Text,
                city = txtCity.Text,
                country_id = "IT",
            };

            switch (type)
            {
                case AddressType.Billing:
                    customerAddress.is_default_billing = true;
                    break;
                case AddressType.Shipping:
                    customerAddress.is_default_shipping = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("type");
            }
            _businessDelegate.CreateCustomerAddress(id, customerAddress);
        }

        private string CreateMagentoCustomer()
        {
            var customer = new Customer
            {
                firstname = txtFirstName.Text,
                lastname = txtLastName.Text,
                email = txtEmail.Text,
                created_at = DateTime.Now.ToString(CultureInfo.InvariantCulture),
            };
            return _businessDelegate.CreateCustomer(customer);
        }

        protected void cuwUser_OnCreatingUser(object sender, LoginCancelEventArgs e)
        {
            cuwUser.Email = txtEmail.Text;
        }
    }
}