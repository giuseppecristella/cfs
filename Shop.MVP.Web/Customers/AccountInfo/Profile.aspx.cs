using System;
using System.Web.Security;

namespace Shop.Web.Mvp.Customers.AccountInfo
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnChangePassword_OnClick(object sender, EventArgs e)
        {
            var oldPassword = Password.Text;
            var newPassword = NewPassword.Text;
            var membershipUser = Membership.GetUser(Page.User.Identity.Name);
            if (membershipUser == null) return;
            lblPasswordChangedResult.Text = membershipUser.ChangePassword(oldPassword, newPassword) ? "Password modificata con successo." : "Errore modifica password.";
        }
    }
}