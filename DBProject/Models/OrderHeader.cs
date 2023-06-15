using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProject.Models
{
    public class OrderHeader
    {
        [Key]
        [Column("SalesOrderID")]
        public int SalesOrderID { get; set; }
        [Column("CustomerID")]
        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }
        public ICollection<Order> OrderDetails { get; set; }
    }
}
