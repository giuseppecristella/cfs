﻿using System.Collections.Generic;
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

    }
}
