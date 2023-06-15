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
    public partial class Order
    {
        [Key]
        [Column("SalesOrderID")]
        public int SalesOrderID { get; set; }
        public int SalesOrderDetail { get; set; }
        public int OrderQty { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitPriceDiscount { get; set; }
        public decimal LineTotal { get; set; }
        public string rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
