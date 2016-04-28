using System.Text;
using System.Web;

namespace Shop.Web.Mvp.Infrastructure.Paypal
{
    /// <summary>
    /// Summary description for payPalUrl.
    /// </summary>
    public class PayPalHelper
    {
        public string LogoUrl = "";
        public string AccountEmail = "";
        public string BuyerEmail = "";
        public string SuccessUrl = "";
        public string CancelUrl = "";
        public string ItemName = "";
        public decimal Amount = 1.10M;
        public string InvoiceNo = "";


        public string PayPalBaseUrl = "https://www.sandbox.paypal.com/us/cgi-bin/webscr?";
            //"https://www.paypal.com/cgi-bin/webscr?";
            //"https://www.paypal.com/cgi-bin/webscr?";
        

        public string LastResponse = "";

        public PayPalHelper()
        {

        }

        public string GetSubmitUrl()
        {
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";

            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

            StringBuilder url = new StringBuilder();

            url.Append(this.PayPalBaseUrl + "cmd=_xclick&business=" +
                HttpUtility.UrlEncode(AccountEmail));

            if (!string.IsNullOrEmpty(BuyerEmail))
                url.AppendFormat("&email={0}", HttpUtility.UrlEncode(BuyerEmail));

            if (Amount != 0.00M)
                url.AppendFormat("&amount={0:f2}", Amount);

            if (!string.IsNullOrEmpty(LogoUrl))
                url.AppendFormat("&image_url={0}", HttpUtility.UrlEncode(LogoUrl));

            if (!string.IsNullOrEmpty(ItemName))
                url.AppendFormat("&item_name={0}", HttpUtility.UrlEncode(ItemName));

            if (!string.IsNullOrEmpty(InvoiceNo))
                url.AppendFormat("&invoice={0}", HttpUtility.UrlEncode(InvoiceNo));

            if (!string.IsNullOrEmpty(SuccessUrl))
                url.AppendFormat("&return={0}", HttpUtility.UrlEncode(SuccessUrl));

            if (!string.IsNullOrEmpty(CancelUrl))
                url.AppendFormat("&cancel_return={0}", HttpUtility.UrlEncode(CancelUrl));

            return url.ToString();
        }

        /// <summary>
        /// Posts all form variables received back to PayPal. This method is used on 
        /// is used for Payment verification from the 
        /// </summary>
        /// <returns>Empty string on success otherwise the full message from the server</returns>
        public bool IPNPostDataToPayPal(string payPalUrl, string payPalEmail)
        {
            HttpRequest request = HttpContext.Current.Request;
            LastResponse = "";

            // *** Make sure our payment goes back to our own account
            string email = request.Form["receiver_email"];
            if (email == null || email.Trim().ToLower() != payPalEmail.ToLower())
            {
                LastResponse = "Invalid receiver email";
                return false;
            }

            //wwHttp Http = new wwHttp();
            //Http.AddPostKey("cmd", "_notify-validate");

            //foreach (string postKey in Request.Form)
            //    Http.AddPostKey(postKey, Request.Form[postKey]);

            //// *** Retrieve the HTTP result to a string
            //this.LastResponse = Http.GetUrl(payPalUrl);

            return LastResponse == "VERIFIED";
        }

    }
}