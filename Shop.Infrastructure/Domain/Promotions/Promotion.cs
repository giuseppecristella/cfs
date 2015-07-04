using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Domain.Promotions
{
    public partial class Promotion : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
