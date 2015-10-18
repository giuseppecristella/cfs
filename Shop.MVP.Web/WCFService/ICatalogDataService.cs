using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Ez.Newsletter.MagentoApi;
using Shop.Core.Domain.ProductsCart;

namespace Shop.Web.Mvp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICatalogDataService" in both code and config file together.
    [ServiceContract]
    public interface ICatalogDataService
    {
        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, Method = "GET")]
        List<CategoryAssignedProduct> GetProducts();

        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, Method = "GET")]
        List<CategoryAssignedProduct> GetProductsByCategoryName(string categoryName);

        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, Method = "POST", RequestFormat = WebMessageFormat.Json)]
        bool AddProductToSessionCart(List<ProductCart> products);

        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, Method = "GET")]
        List<ProductCart> GetProductsFromSessionCart();
    }

   
}
