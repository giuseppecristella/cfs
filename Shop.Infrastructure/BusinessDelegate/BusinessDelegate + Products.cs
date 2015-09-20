using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CookComputing.XmlRpc;
using Ez.Newsletter.MagentoApi;
using MagentoRepository.Repository;

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
    }
}
