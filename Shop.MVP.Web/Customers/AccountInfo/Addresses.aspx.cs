using System;
using Ez.Newsletter.MagentoApi;

namespace Shop.Web.Mvp.Customers.AccountInfo
{
    public partial class Addresses : System.Web.UI.Page
    {
        public CustomerAddress AddressVM { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            AddressVM = new CustomerAddress();
            AddressVM.firstname = "Giuseppe";
        }
    }
}