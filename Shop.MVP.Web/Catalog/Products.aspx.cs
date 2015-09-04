using System;
using System.Collections.Generic;
using Shop.Web.Mvp.UserControls;

namespace Shop.Web.Mvp.Catalog
{
    public partial class Products : System.Web.UI.Page
    {
        private readonly List<string> _specialCategories = new List<string> { "nuovi-arrivi", "promozioni" };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            SetBreadcrumbs();
        }

        private void SetBreadcrumbs()
        {
            UCBreadcrumbs.Detail = new BreadCrumb { Name = string.Empty, Url = string.Empty };
            var url = ((System.Web.Routing.Route)(RouteData.Route)).Url;
            if (_specialCategories.Contains(url))
            {
                UCBreadcrumbs.MainLevel = new BreadCrumb { Name = url, Url = url };
                return;
            }
            var splittedUrl = url.Split('-');
            if (splittedUrl.Length < 2) return;
            UCBreadcrumbs.MainLevel = new BreadCrumb { Name = splittedUrl[0], Url = string.Concat("/", splittedUrl[0]) };
            UCBreadcrumbs.SecondLevel = new BreadCrumb { Name = splittedUrl[1], Url = string.Concat("/", url) };
        }
    }
}