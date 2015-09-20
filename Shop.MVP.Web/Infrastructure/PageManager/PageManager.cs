using MagentoRepository.Repository;
using Shop.Core;

namespace Shop.Web.Mvp.Infrastructure.PageManager
{
    public class PageManager
    {
        private IRepository _repository;

        public PageManager()
        {
            _repository = RepositoryFactory.GetRepositoryService();
        }


    }
}