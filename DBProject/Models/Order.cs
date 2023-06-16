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
        public OrderHeader OrderHeader { get; set; }
        [ForeignKey("OrderHeader")]
        [Column("SalesOrderID")] // Specify the actual column name in the database
        public int SalesOrderID { get; set; }
        [Key]
        [Column("SalesOrderDetailID")]
        public int SalesOrderDetailID { get; set; }
        public short OrderQty { get; set; }
        [ForeignKey("ProductID")]
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitPriceDiscount { get; set; }
        public decimal LineTotal { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}