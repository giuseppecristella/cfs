using System;
using System.Linq;
using Shop.Core.BusinessDelegate;
using Shop.Web.Mvp.Infrastructure;

namespace Shop.Web.Mvp.Home.UserControls
{
    public partial class UCShowcaseProducts : System.Web.UI.UserControl
    {
        private BusinessDelegate _businessDelegate;

        public UCShowcaseProducts()
        {
            _businessDelegate = new BusinessDelegate();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            rptShowcaseProducts.DataSource = _businessDelegate.GetProductsByCategoryId(App.CategoryName.NuoviArrivi).Take(4);
            rptShowcaseProducts.DataBind();
        }
    }
}