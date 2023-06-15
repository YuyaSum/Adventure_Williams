using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DBProject.Models;


namespace DBProject.Context;

public class AWContext : DbContext
{
    public AWContext() { }

    public AWContext(DbContextOptions<AWContext> options) : base(options)
    {
    }
    private readonly IConfiguration _configuration;
    
    public virtual DbSet<Customer> Customer { get; set; } = null!;
    public virtual DbSet<Products> Products { get; set; } = null!;
    public virtual DbSet<Order> Orders { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Products>().ToTable("Product","SalesLT");
        modelBuilder.Entity<Customer>().ToTable("Customer", "SalesLT");
        modelBuilder.Entity<Order>().ToTable("SalesOrderDetail", "SalesLT");
            
        base.OnModelCreating(modelBuilder);
    }
}
