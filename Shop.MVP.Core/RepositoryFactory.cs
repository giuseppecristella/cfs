using MagentoRepository.Connection;
using MagentoRepository.Repository;
using Shop.Core.Cache;

namespace Shop.MVP.Core
{
  /// <summary>
  /// Classe responsabile di fornire le istanze concrete del repository.
  /// </summary>
  public static class RepositoryFactory
  {
    public static RepositoryService GetRepositoryService()
    {
      return new RepositoryService(MagentoConnection.Instance, new ELCacheManager());
    }
  }
}
