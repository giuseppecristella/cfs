using System;
using System.Globalization;
using System.Net.Mail;
using System.Web.Security;
using System.Web.UI.WebControls;
using Ez.Newsletter.MagentoApi;
using Shop.Core.BusinessDelegate;
using Shop.Web.Mvp.Infrastructure;

namespace Shop.Web.Mvp.Checkout
{
    public enum AddressType
    {
        Billing,
        Shipping
    }

    public partial class Checkout : System.Web.UI.Page
    {
        private BusinessDelegate _businessDelegate;

        public Checkout()
        {
            _businessDelegate = new BusinessDelegate();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            BindPaymentMethods();
        }

        protected void OnLoggedIn(object sender, EventArgs e)
        {
            var username = Page.User.Identity.Name;
            var aspNetUser = Membership.GetUser(username);
            var magentoUserId = aspNetUser.Comment;

            //if (!int.TryParse(magentoUserId, out _customerId)) return;
            //var customer = _repository.GetCustomerById(_customerId);
            BindUserInfo();

            if (Roles.IsUserInRole(Login.UserName, "Administrator"))
            {

            }
        }

        private void BindUserInfo()
        {
            throw new NotImplementedException();
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

        protected void CreateMagentoUser(object sender, EventArgs e)
        {
            var usernameFromUI = CreateUserWizard1.UserName;
            var passwordFromUI = CreateUserWizard1.Password;
            var membershipUser = Membership.GetUser(usernameFromUI);
            if (membershipUser == null) return;
            try
            {
                Roles.AddUserToRole(usernameFromUI, "User");
                var magentoCustomerId = CreateMagentoCustomer();

                // Salvo nel campo 'comment' dell'oggetto User di membership provider il customer Id di Magento prodotto
                membershipUser.Comment = magentoCustomerId;
                Membership.UpdateUser(membershipUser);

                // SubscriveSignedCustomerToNewsLetter();
                SendNotificationEmailToSignedCustomer(membershipUser.UserName, passwordFromUI);
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

        private string CreateMagentoCustomer()
        {
            var customer = new Customer()
            {
                firstname = txtFirstName.Text,
                lastname = txtLastName.Text,
                email = CreateUserWizard1.Email,
                created_at = DateTime.Now.ToString(CultureInfo.InvariantCulture),
            };
            return _businessDelegate.CreateCustomer(customer);
        }

        private void CreateMagentoCustomerAddress(AddressType type, string customerId)
        {
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
            int id;
            if (!int.TryParse(customerId, out id)) return;
            _businessDelegate.CreateCustomerAddress(id, customerAddress);
        }

        private void SendNotificationEmailToSignedCustomer(string username, string passwordFromUI)
        {
            try
            {
                var from = new MailAddress("info@calzafacile.com", "CalzaFacile");
                var to = new MailAddress(CreateUserWizard1.Email, string.Format("{0} {1}", txtFirstName.Text, txtLastName.Text));
                var email = new MailMessage(@from, to)
                {
                    Subject = "Conferma creazione account shop Calzafacile",
                    IsBodyHtml = true
                };
                var header =
                  string.Format(
                    "<img alt='header' src='http://www.calzafacile.com/images/logo_header.jpg' /> " +
                    "<br><br>Creazione account Shop <b style='color:#bf00000'>Calzafacile</b> di: {0} <br><br>",
                    CreateUserWizard1.Email);
                email.Body =
                  string.Format(
                    "{0}Gentile {1} {2},<br> le confermiamo l'iscrizione al nostro Shop.<br><br>Riepilogo dati di accesso: <br>Utente:" +
                    "{3}<br>Password: {4}<br>" + "<br><a href=\"http://www.calzafacile.it/shop/accedi.html\">" +
                    "Cliccando qui</a> può accedere al suo account e verificare lo stato dei suoi ordini.",
                    header, txtFirstName.Text, txtLastName.Text, username, passwordFromUI);
                email.Bcc.Add("");
                email.Bcc.Add("info@calzafacile.com"); // Settare in variabili di configurazione
                var smtpMail = new SmtpClient();
                smtpMail.Send(email);
            }
            catch (Exception ex)
            {

            }
        }

        protected void CreateUserWizard1_OnCreatingUser(object sender, LoginCancelEventArgs e)
        {
            CreateUserWizard1.Email = "test-01@libero.it";
        }

        private void BindPaymentMethods()
        {
            rdbtnListPayMethods.DataSource = App.PaymentMethods;
            rdbtnListPayMethods.DataTextField = "value";
            rdbtnListPayMethods.DataValueField = "key";
            rdbtnListPayMethods.DataBind();
        }
    }
}