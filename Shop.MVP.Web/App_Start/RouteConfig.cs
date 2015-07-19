using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace Shop.Web.Mvp
{
  public static class RouteConfig
  {
    public static void RegisterRoutes(RouteCollection routes)
    {
        var settings = new FriendlyUrlSettings { AutoRedirectMode = RedirectMode.Permanent };
        routes.EnableFriendlyUrls(settings);

        routes.MapPageRoute("DonnaCiabatte", "donna-ciabatte", "~/Catalog/Products.aspx");
        routes.MapPageRoute("DonnaSandali", "donna-sandali", "~/Catalog/Products.aspx");
        routes.MapPageRoute("DonnaInfradito", "donna-infradito", "~/Catalog/Products.aspx");
        routes.MapPageRoute("DonnaZeppe", "donna-zeppe", "~/Catalog/Products.aspx");
        //routes.MapPageRoute("Landing", "Landing", "~/Landing/Default.aspx");
        routes.MapPageRoute("Landing-2", "", "~/Landing/Default.aspx");

    }
  }
}
