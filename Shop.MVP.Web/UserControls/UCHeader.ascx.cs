using System;
using System.Web.Security;

namespace Shop.Web.Mvp.UserControls
{
    public partial class UCHeader : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbLogout_OnClick(object sender, EventArgs e)
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            Response.Redirect("~/");
        }
    }
}