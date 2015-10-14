using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shop.Data;

namespace Shop.Web.Mvp.Admin
{
    public partial class PromoSubscriptions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var ctx = new ShopDataContext())
            {
                gvUsers.DataSource =  ctx.Newslettersubscriptions.ToList();
                gvUsers.DataBind();
            }
        }
    }
}