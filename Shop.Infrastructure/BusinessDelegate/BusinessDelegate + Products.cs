using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CookComputing.XmlRpc;
using Ez.Newsletter.MagentoApi;
using MagentoRepository.Repository;
using Shop.Core.Domain.ProductsCart;

namespace Shop.Core.BusinessDelegate
{
    public partial class BusinessDelegate
    {
        private IRepository _repository;

        public BusinessDelegate(IRepository repository)
        {
            _repository = repository;
        }

        public BusinessDelegate()
            : this(RepositoryFactory.GetRepositoryService())
        {

        }

        public IEnumerable<XmlRpcStruct> GetMainLevelCategories(string rootCategoryId)
        {
            var rootCategory = _repository.GetCategoryLevel(rootCategoryId) as Hashtable;
            return (rootCategory["children"] as object[]).ToList().Select(sc => sc as XmlRpcStruct);
        }

        public List<CategoryAssignedProduct> GetProductsByCategoryId(string rootCategoryId)
        {
            return _repository.GetProductsByCategoryId(rootCategoryId);
        }

        public Product GetProduct(string productId)
        {
            return _repository.GetProductInfo(productId);
        }

        public List<ProductImage> GetProductImages(string productId)
        {
            return _repository.GetProductImages(productId);
        }

        public Product GetProductInfo(string id)
        {
            return _repository.GetProductInfo(id);
        }

        public void UpdateProduct(IList<Product> products)
        {
            // size
            foreach (Product product in products)
            {
                var selectedSize = (((string[])(product.additional_attributes[0]))[1]);
                var sizeProperties = product.GetType().GetProperties().FirstOrDefault(p => p.Name.Contains(string.Format("tg_{0}", selectedSize)));
                if (sizeProperties == null) continue;
                sizeProperties.SetValue(product, product.qty);
                _repository.UpdateProduct(product);
            }
        }
    }
}
