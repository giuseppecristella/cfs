using System;

namespace Shop.Web.Mvp
{
    public partial class Newsletter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var query = RouteData.Values["Succcess"].ToString();
            var query2 = RouteData.Values["AlreadySubscribed"].ToString();
        }
    }
}