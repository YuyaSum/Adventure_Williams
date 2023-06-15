using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace DBProject.Models
{
    public class Order
    {
        //[Column("CustomerID")]
        //public int CustomerID { get; set; }
        //[ForeignKey("CustomerID")]
        //public Customer Customer { get; set; }
        //public ICollection<OrderHeader> orderHeader { get; set; }
        public int SalesOrderID { get; set; }
        [Key]
        public int SalesOrderDetailID { get; set; }
        public int OrderQty { get; set; }
        [ForeignKey("ProductID")]
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitPriceDiscount { get; set; }
        public decimal LineTotal { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
