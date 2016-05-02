using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Web;
using System.Web.Script.Services;
using Ez.Newsletter.MagentoApi;
using Shop.Core;
using Shop.Core.BusinessDelegate;
using Shop.Core.Domain.Brands;
using Shop.Core.Domain.ProductsCart;
using Shop.Data;
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

        /// <summary>
        /// Recupera il prezzo dal db in modo da evitare manipolazioni lato client
        /// e infine Aggiunge il prodotto al carrello persistendo i dati in sessione
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        public bool AddProductToSessionCart(List<ProductCart> products)
        {
            SetPrice(products);

            if (HttpContext.Current.Session == null) return false;
            SessionFacade.ProductsCart = products;
            //HttpContext.Current.Session.Add("Products", products);
            return true;
        }

        public List<ProductCart> GetProductsFromSessionCart()
        {
            // Necessario perchè IE di default salva la response nella cache
            // http://galratner.com/blogs/net/archive/2009/09/07/how-to-prevent-the-browser-from-caching-wcf-json-responses.aspx
            if (WebOperationContext.Current != null) WebOperationContext.Current.OutgoingResponse.Headers.Add("Cache-Control", "no-cache");
            if (HttpContext.Current.Session == null) return null;
            return SessionFacade.ProductsCart;
            //  HttpContext.Current.Session["Products"] as List<ProductCart>;
        }

        private void SetPrice(IEnumerable<ProductCart> products)
        {
            foreach (var product in products)
            {
                var savedProduct = _businessDelegate.GetProduct(product.Id);
                if (savedProduct == null) continue;
                int price;
                //if (!int.TryParse(savedProduct.price, out price)) continue;
                product.Price = savedProduct.price;
            }
        }

        public List<Brand> GetBrandsByCategory()
        {
            using (var ctx = new ShopDataContext())
            {
                var category = ctx.Set<Shop.Core.Domain.Categories.Category>().FirstOrDefault(c => c.Id.Equals(1));
                var brands = new List<Brand>();
                brands = category.Brands.ToList();
                return brands;
                // return category == null ? null : category.Brands.ToList();
            }
        }
    }


}
