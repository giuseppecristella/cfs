using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Shop.Data.Tests
{
    [DataContract]
    public class ProductCart
    {
        [DataMember(Name = "Name")]
        public string Name { get; set; }
    }
}
