using System;
using Microsoft.AspNet.FriendlyUrls;

namespace Shop.Web.Mvp
{
    public partial class Newsletter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var result = Request.GetFriendlyUrlSegments();
            if (result == null) return;
            if (result.ToString().Equals("Success"))
            {
                ltResult.Text =
                    "La tua iscrizione alla Newsletter è stata completata con successo. <br> Sarai aggiornato sulle nostre offerte e novità!";
                return;
            }
            if (result.ToString().Equals("AlreadySubscribed"))
            {
                ltResult.Text = "Ciao. Risulti già iscritto alla nostra Newsletter!";
            }
        }
    }
}