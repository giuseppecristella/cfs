using System.Collections.Generic;

namespace Shop.Core.Domain.Brands
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Categories.Category> Categories { get; set; }
    }
}
