//using System.ComponentModel.DataAnnotations.Schema;

//namespace Shop.Data
//{
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;

//    public partial class OrderProduct
//    {
//         [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//        public int Id { get; set; }
//        public int OrderId { get; set; }
//        public string Name { get; set; }
//        public decimal UnitPrice { get; set; }
//        public int Qty { get; set; }
//        public decimal TotalPrice { get; set; }
//        public virtual Order Order { get; set; }
//        public int Size { get; set; }
//    }
//}
