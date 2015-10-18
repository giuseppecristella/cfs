using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Web.ModelBinding;
using System.Web.Security;
using System.Web.UI.WebControls;
using Ez.Newsletter.MagentoApi;
using Shop.Core;
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
        private readonly BusinessDelegate _businessDelegate;

        #region CTor
        public Checkout()
        {
            _businessDelegate = new BusinessDelegate();
        } 
        #endregion

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            //TODO: Classe base check Session redirect nel page load
            BindPaymentMethods();
            LoadUserInfoIfLogged();

            if (SessionFacade.ProductsCart == null)
            {
                mvContainer.ActiveViewIndex = 0;
                return;
            }

            if (SessionFacade.CartId.Equals(0))
            {
                SessionFacade.CartId = _businessDelegate.CreateCart();
                if (SessionFacade.CartId.Equals(-1))
                {
                    // Errore creazione carrello
                    // 1. Log Exception 2. Alert 3. Redirect
                }
            }

        }

        protected void cuwUser_OnCreatedUser(object sender, EventArgs e)
        {
            var membershipUser = Membership.GetUser(cuwUser.UserName);
            if (membershipUser == null) return;
            try
            {
                Roles.AddUserToRole(cuwUser.UserName, "User");
                // TODO: Check errore creazione utente lato Magento
                var magentoCustomerId = CreateMagentoCustomer();

                // Salvo nel campo 'comment' dell'oggetto User di MembershipProvider il customer CustomerId di Magento
                membershipUser.Comment = magentoCustomerId;
                Membership.UpdateUser(membershipUser);

                // SubscriveSignedCustomerToNewsLetter();
                SendNotificationEmailToSignedCustomer(membershipUser.UserName, cuwUser.Password);
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

        protected void cuwUser_OnCreatingUser(object sender, LoginCancelEventArgs e)
        {
            cuwUser.Email = txtEmail.Text;
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

        }

        protected void btnCheckout_OnClick(object sender, EventArgs e)
        {
            BindDataObjects();
        }

        private void BindDataObjects()
        {
            var dataObject = new CustomerVM();

            if (TryUpdateModel(dataObject, new FormValueProvider(ModelBindingExecutionContext)))
            {
 
            } 
        }

        #endregion

        #region Bindings
        private void BindCustomerAddresses(List<CustomerAddress> customerAddresses)
        {
            var shipmentAddress = customerAddresses.First(a => a.is_default_billing);
            txtCity.Text = shipmentAddress.city;
            txtStreet.Text = shipmentAddress.street;
            txtZipCode.Text = shipmentAddress.postcode;
            txtPhone.Text = shipmentAddress.telephone;
        }

        private void BindUserInfo(Customer customer)
        {
            txtFirstName.Text = customer.firstname;
            txtLastName.Text = customer.lastname;
            txtEmail.Text = customer.email;
        }

        private void BindPaymentMethods()
        {
            rdbtnListPayMethods.DataSource = App.PaymentMethods;
            rdbtnListPayMethods.DataTextField = "value";
            rdbtnListPayMethods.DataValueField = "key";
            rdbtnListPayMethods.DataBind();
        }


        #endregion

        #region Private Methods
        private void LoadUserInfoIfLogged()
        {
            var aspNetUser = Membership.GetUser(Page.User.Identity.Name);
            if (aspNetUser == null)
            {
                ltTreeStepCheckoutTitle.Text = Resources.Resources.TreeStepCheckoutTitle_NotLogged;
                //pnlShowShipmentAddress.Visible = false;
                return;
            }
            var magentoUserId = aspNetUser.Comment;

            int id;
            if (!int.TryParse(magentoUserId, out id)) return;

            var customer = _businessDelegate.GetCustomerById(id);
            if (customer == default(Customer)) return;
            BindUserInfo(customer);

            var customerAddresses = _businessDelegate.GetCustomerAddresses(id);
            if (customerAddresses == null) return;
            BindCustomerAddresses(customerAddresses);
            pnlCreateNewAccount.Visible = pnlLoggedInUserHeader.Visible = false;
            ltTreeStepCheckoutTitle.Text = Resources.Resources.TreeStepCheckoutTitle_Logged;
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

        /// <summary>
        /// L'indirizzo inserito in interfaccia viene salvato in Magento sia come
        /// ind. di spedizione che come indirizzo di fatturazione
        /// </summary>
        /// <param name="type"></param>
        /// <param name="customerId"></param>
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

        private void SendNotificationEmailToSignedCustomer(string username, string passwordFromUI)
        {
            try
            {
                var from = new MailAddress("info@calzafacile.com", "CalzaFacile");
                var to = new MailAddress(cuwUser.Email, string.Format("{0} {1}", txtFirstName.Text, txtLastName.Text));
                var email = new MailMessage(@from, to)
                {
                    Subject = "Conferma creazione account shop Calzafacile",
                    IsBodyHtml = true
                };
                var header =
                  string.Format(
                    "<img alt='header' src='http://www.calzafacile.com/images/logo_header.jpg' /> " +
                    "<br><br>Creazione account Shop <b style='color:#bf00000'>Calzafacile</b> di: {0} <br><br>",
                    cuwUser.Email);
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
        #endregion

    }

    public class CustomerVM
    {
        public string FirstName { get; set; }
    }
}