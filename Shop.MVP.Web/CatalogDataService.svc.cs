using System.Collections.Generic;
using System.Web.UI.WebControls;
using Ez.Newsletter.MagentoApi;
using MagentoComunication.Helpers;
using Shop.MVP.Core;

namespace Shop.Web.Mvp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CatalogDataService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CatalogDataService.svc or CatalogDataService.svc.cs at the Solution Explorer and start debugging.
    public class CatalogDataService : ICatalogDataService
    {
        public List<CategoryAssignedProduct> GetProducts()
        {
            var repository = RepositoryFactory.GetRepositoryService();
            var p = repository.GetProductsByCategoryId(ConfigurationHelper.RootCategory);
            return p;
        }


        public List<CategoryAssignedProduct> GetProductsByCategoryName(string categoryName)
        {
            var categoryId = ConfigurationHelper.RootCategory;
            var repository = RepositoryFactory.GetRepositoryService();

            if (string.IsNullOrEmpty(categoryName)) return null;

            // Soluzione provvisoria: rifattorizzare per recuperare id categoria dal db
            switch (categoryName)
            {
                case "donna-ciabatte":
                {
                    categoryId = "7";
                    break;
                }
                case "donna-infradito":
                {
                    categoryId = "21";
                    break;
                }
                case "donna-zeppe":
                {
                    categoryId = "24";
                    break;
                }
                case "donna-sandali":
                {
                    categoryId = "8";
                    break;
                }
            }

            var p = repository.GetProductsByCategoryId(categoryId);
            return p;
        }

    }
}
