using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using Ez.Newsletter.MagentoApi;

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

    [DataContract]
    public class ProductCart
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "qta")]
        public int Qta { get; set; }

        [DataMember(Name = "price")]
        public int Price { get; set; }

        [DataMember(Name = "image")]
        public string Image { get; set; }

        [DataMember(Name = "size")]
        public string Size { get; set; }
    }
}
