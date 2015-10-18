using System.Runtime.Serialization;

namespace Shop.Core.Domain.ProductsCart
{
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
        public string Price { get; set; }

        [DataMember(Name = "image")]
        public string Image { get; set; }

        [DataMember(Name = "size")]
        public string Size { get; set; }
    }
}
