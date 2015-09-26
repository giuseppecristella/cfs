using System.Collections.Generic;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Script.Services;
using Ez.Newsletter.MagentoApi;
using Shop.Core.BusinessDelegate;
using Shop.Web.Mvp.Infrastructure;

namespace Shop.Web.Mvp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CatalogDataService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CatalogDataService.svc or CatalogDataService.svc.cs at the Solution Explorer and start debugging.
    [ScriptService]
    // L'attributo seguente abilita l'accesso alla Asp.Net Session
    // Per abilitarla in una web api: http://chsakell.com/2015/03/07/angularjs-feat-web-api-enable-session-state/
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class CatalogDataService : ICatalogDataService
    {
        private BusinessDelegate _businessDelegate;
        public CatalogDataService()
        {
            _businessDelegate = new BusinessDelegate();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<CategoryAssignedProduct> GetProducts()
        {
            return _businessDelegate.GetProductsByCategoryId(App.CategoryName.Root);
        }

        /// <summary>
        /// Recupera dal dizionario l'id relativo alla categoria in input (es. donna-ciabatte)
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        public List<CategoryAssignedProduct> GetProductsByCategoryName(string categoryName)
        {
            return !App.CategoriesDictionary.ContainsKey(categoryName) ? null : _businessDelegate.GetProductsByCategoryId(App.CategoriesDictionary[categoryName]);
        }

        public bool AddProductToSessionCart(List<ProductCart> products)
        {
            if (HttpContext.Current.Session == null) return false;
            HttpContext.Current.Session.Add("Products", products);
            return true;
        }

        public List<ProductCart> GetProductsFromSessionCart()
        {
            if (HttpContext.Current.Session == null) return null;
            return HttpContext.Current.Session["Products"] as List<ProductCart>;
        }
    }


}
