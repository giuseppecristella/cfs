using System;
using System.Collections;
using System.Linq;
using Shop.Core.Utility;
using Shop.Data;
using Shop.Web.Mvp.MailSenderService;

namespace Shop.Web.Mvp.Landing
{

    public enum MessageType
    {
        Error,
        Success
    }

    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HideNotificationMessage();
        }

        protected void btnNesletterSubscribe_OnClick(object sender, EventArgs e)
        {
            using (var ctx = new ShopDataContext())
            {
                var entity = new Newslettersubscription()
                {
                    Email = txtEmail.Text
                };

                // Verifica se l'indirizzo è già presente in archivio
                if (IsAlreadySubscribed())
                {
                    ltErrorMessage.Text = Resources.Resources.E_mailAlreadyPresent;
                    ShowNotification(MessageType.Error);
                    return;
                }

                // Check codice già assegnato a quell'indirizzo per quella promo
                if (HaveAlreadyPromoCodeForPromotion())
                {
                    ltErrorMessage.Text = Resources.Resources.PromoCodeAlreadySended;
                    ShowNotification(MessageType.Error);
                    return;
                }

                var firstNotAssignedCode = ctx.PromotionCodes.FirstOrDefault(pc => pc.Newslettersubscription == null);

                if (firstNotAssignedCode == null)
                {
                    // non ci sono più codici disponibili; log
                    return;
                }

                firstNotAssignedCode.IsAssigned = true;
                firstNotAssignedCode.NewslettersubscriptionEmail = entity.Email;
                entity.PromotionCodes.Add(firstNotAssignedCode);

                // Save
                ctx.Set<Newslettersubscription>().Add(entity);
                ctx.SaveChanges();

                // Invio notifica 
                SendMailToUserFromWCF(entity.Email, firstNotAssignedCode.Code);
               // SendMailToUser(entity.Email, firstNotAssignedCode.Code);
            }
        }

        #region Private Methods

        private bool IsAlreadySubscribed()
        {
            var ctx = new ShopDataContext();
            return (ctx.Newslettersubscriptions.FirstOrDefault(n => n.Email.Equals(txtEmail.Text)) != null);
        }

        private bool HaveAlreadyPromoCodeForPromotion()
        {
            var ctx = new ShopDataContext();
            return ctx.PromotionCodes.FirstOrDefault(pc => pc.Newslettersubscription.Email.Equals(txtEmail.Text) && pc.PromotionId.Equals(1)) != null;
        }

        private void SendMailToUser(string newsletterSubscriptionAddress, string promotionCode)
        {
            string templateName = "PromoStart.html";
            var templatePath = Server.MapPath(string.Format("~\\MailTemplates\\PromoStart\\{0}", templateName));

            var mailManager = new MailManager()
            {
                MailTo = newsletterSubscriptionAddress,
                MailFrom = "info@calzafacile.com",
                MailSubject = "Che belle che gratis le infradito che ti regala Calzafacile",
                DisplayName = "Calzafacile",

                MailTemplate = templatePath,
                MailParameters = new Hashtable
                {
                    {"##CouponeCode##", promotionCode},
                }
            };
            mailManager.SendMail();

            ltSuccessMessage.Text = "Controlla la tua mail, ti abbiamo inviato un codice promo!<br>Se non visualizzi la nostra mail controlla la tua cartella di posta indesiderata.";
            ShowNotification(MessageType.Success);
        }

        private void SendMailToUserFromWCF(string newsletterSubscriptionAddress, string promotionCode)
        {
            var mailSenderService = new Service1Client();
            mailSenderService.SendNotificationToSubscriber(newsletterSubscriptionAddress, promotionCode);

            ltSuccessMessage.Text = "Controlla la tua mail, ti abbiamo inviato un codice promo!<br>Se non visualizzi la nostra mail controlla la tua cartella di posta indesiderata.";
            ShowNotification(MessageType.Success);
        }

        private void HideNotificationMessage()
        {
            divError.Style["display"] = "none";
            divSuccess.Style["display"] = "none";
        }

        private void ShowNotification(MessageType type)
        {
            if (type.Equals(MessageType.Error))
            {
                divError.Style["display"] = "block";
                divSuccess.Style["display"] = "none";
            }
            else
            {
                divError.Style["display"] = "none";
                divSuccess.Style["display"] = "block";
            }
        }
        #endregion
    }
}