using System.Configuration;

namespace Shop.Web.Mvp.Infrastructure
{

    public class Configuration
    {
        public string TestEnvironment
        {
            get
            {
                return ConfigurationManager.AppSettings["Environment"];
            }
        }

        public string AddressModeShipping
        {
            get { return "shipping"; }
        }

        public string AddressModeBilling
        {
            get { return "billing"; }
        }

        public string DefaultShippingRegion
        {
            get { return "ita"; }
        }

        public string DefaultShippingCountryId
        {
            get { return "2"; }
        }

        public string PaymentPoNumber
        {
            get { return "po_number"; }
        }
        public string DefaultShippingMethodMode
        {
            get { return "flatrate_flatrate"; }
        }
        public string DefaultCustomerMode
        {
            get { return "register"; }
        }
    }
}