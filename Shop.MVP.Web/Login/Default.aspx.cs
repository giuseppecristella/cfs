using System;
using System.Web.Security;
using System.Web.UI.WebControls;
using Shop.Web.Mvp.Checkout;

namespace Shop.Web.Mvp.Login
{
    public partial class Default : System.Web.UI.Page
    {
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

                // SubscriveSignedCustomerToNewsLetter();
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

        private void CreateMagentoCustomerAddress(AddressType shipping, string magentoCustomerId)
        {
            throw new NotImplementedException();
        }

        private string CreateMagentoCustomer()
        {
            throw new NotImplementedException();
        }

        protected void cuwUser_OnCreatingUser(object sender, LoginCancelEventArgs e)
        {
            //cuwUser.Email = txtEmail.Text;
        }
    }
}