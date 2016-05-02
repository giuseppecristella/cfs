using System.Linq;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;
using Shop.Web.Mvp.Infrastructure;

namespace Shop.Web.Mvp
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings { AutoRedirectMode = RedirectMode.Permanent };
            routes.EnableFriendlyUrls(settings);

            //routes.MapPageRoute("Landing-2", "", "~/Landing/Default.aspx");
            routes.MapPageRoute("Home", "", "~/Home/Default.aspx");
            foreach (var categoryName in App.CategoriesDictionary.Keys)
            {
                routes.MapPageRoute(categoryName, categoryName, "~/Catalog/Products.aspx");
            }
            routes.MapPageRoute("login", "login/{returnurl}", "~/login/default.aspx");
            routes.MapPageRoute("spedizioni", "spedizioni", "~/Catalog/spedizioni.aspx");
            // Prodotto Singolo
            routes.MapPageRoute("ProdottoSingolo", "{productName}/{productId}", "~/Catalog/SingleProduct.aspx");
            routes.MapPageRoute("ProdottoSingolo2", "prodotto/{productId}/{productName}", "~/Catalog/SingleProduct.aspx");
            // Categorie Principali
            routes.MapPageRoute("CatalogoDonna", "donna", "~/Catalog/ProductsCatalogDonna.aspx");
            routes.MapPageRoute("CatalogoUomo", "uomo", "~/Catalog/ProductsCatalogUomo.aspx");
            routes.MapPageRoute("CatalogoBambino", "bambino", "~/Catalog/ProductsCatalogBambino.aspx");
            routes.MapPageRoute("CondizioniVendita", "condizionigenerali", "~/Catalog/CondizioniVendita.aspx");
            routes.MapPageRoute("privacy", "privacy", "~/Catalog/Privacy.aspx");
            // routes.MapPageRoute("spedizioni", "spedizioni", "~/Catalog/spedizioni.aspx");
            // Newsletter
            routes.MapPageRoute("Newsletter", "Newsletter/{NewsletterResult}", "~/Newsletter.aspx");
        }
    }
}
