using System.Data.Entity.ModelConfiguration;

namespace Shop.Data.Mapping
{
    public class ShopEntityTypeConfiguration<T> : EntityTypeConfiguration<T> where T : class
    {
        public ShopEntityTypeConfiguration()
        {
            PostInitialize();
        }

        /// <summary>
        /// Developers can override this method in custom partial classes
        /// in order to add some custom initialization code to constructors
        /// </summary>
        protected virtual void PostInitialize()
        {

        }
    }
}
