﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProject.Models
{
    public class Products
    {
        [Key]
        [Column("ProductID")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public string? Color { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public string? Size { get; set; }
        public decimal? Weight { get; set; }
        public int? ProductCategoryID { get; set; }
        public int? ProductModelID { get; set; }
        public DateTime SellStartDate { get; set; }
        public DateTime? SellEndDate { get; set;}
        public DateTime? DiscontinuedDate { get; set;}
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}