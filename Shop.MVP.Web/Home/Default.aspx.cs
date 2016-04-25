using System;
using System.Linq;
using Shop.Core.Utility;
using Shop.Data;

namespace Shop.Web.Mvp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            //var webAddr = "http://localhost:4992/WCFService/CatalogDataService.svc/AddProductToSessionCart";
            //var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
            //httpWebRequest.ContentType = "application/json; charset=utf-8";
            //httpWebRequest.Method = "POST";

            //using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            //{
            //    string json = "{\"name\":\"peppe\"}";

            //    streamWriter.Write(json);
            //    streamWriter.Flush();
            //}

            //var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            //using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            //{
            //    var result = streamReader.ReadToEnd();

            //}
        }
      
        protected void btnNewsletterSubscibe_OnClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text)) return;
            if (IsAlreadySubscribed(txtEmail.Text)) Response.Redirect("~/Newsletter/AlreadySubscribed");
            using (var ctx = new ShopDataContext())
            {
                var entity = new Newslettersubscription()
                {
                    Email = txtEmail.Text,
                    IsActive = true
                };
                ctx.Set<Newslettersubscription>().Add(entity);
                var saveResult = ctx.SaveChanges();
            }
            // SendConfirmSubscription();
            Response.Redirect("~/Newsletter/Success");
        }

        private bool IsAlreadySubscribed(string email)
        {
            using (var ctx = new ShopDataContext())
            {
                return ctx.Newslettersubscriptions.FirstOrDefault(n => n.Email.Equals(email)) != null;
            }
        }

        private void SendConfirmSubscription()
        {
            var mailManager = new MailManager()
            {
                MailTo = txtEmail.Text,
                MailFrom = "info@calzafacile.com",
                MailSubject = "Benvenuto in Calzafacile!",
                MailTemplate = string.Format("{0}NewsletterSubscription.html", Server.MapPath("~/MailTemplates/Business/")),

                //MailParameters = new Hashtable
                //{
                //    {"##CouponeCode##", "GY2DE-NQPQQ-RV"},
                //},
                DisplayName = "Calzafacile"
            };
            mailManager.SendMail();
        }
    }
}