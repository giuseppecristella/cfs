using System.Collections.Generic;

namespace Shop.Core.Domain.Categories
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Brands.Brand> Brands { get; set; }
    }
}
