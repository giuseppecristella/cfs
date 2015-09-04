using System;

namespace Shop.Web.Mvp.UserControls
{
    public partial class UCBreadcrumbs : System.Web.UI.UserControl
    {
        public static BreadCrumb MainLevel { get; set; }
        public static BreadCrumb SecondLevel { get; set; }
        public static BreadCrumb Detail { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
    }

    public class BreadCrumb
    {
        public string Name;
        public string Url;
    }
}