using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProject.Models
{
    public class CustomerAddress
    {
        [ForeignKey("CustomerID")]
        public int CustomerID { get; set; }
        [Key]
        [Column("AddressID")]
        public int AddressID { get; set; }
        public string AddressType { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
