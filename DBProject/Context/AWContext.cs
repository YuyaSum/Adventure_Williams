using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DBProject.Models;


namespace DBProject.Context;

public partial class AWContext : DbContext
{
    public AWContext() { }

    public AWContext(DbContextOptions<AWContext> options) : base(options)
    {
    }
    private readonly IConfiguration _configuration;

    //public virtual DbSet<Customer> Customers { get; set; } = null!;
    public virtual DbSet<Products> Products { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Products>(entity =>
        {
            entity.ToTable("Product", "SalesLT");
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.ProductNumber).HasMaxLength(50);
            entity.Property(e => e.Color).HasMaxLength(50);
            entity.Property(e => e.StandardCost).HasMaxLength(50);
            entity.Property(e => e.ListPrice).HasMaxLength(50);
            entity.Property(e => e.Size).HasMaxLength(50);
            entity.Property(e => e.Weight).HasMaxLength(50);
            entity.Property(e => e.ProductCategoryID).HasMaxLength(50);
            entity.Property(e => e.ProductModelID).HasMaxLength(50);

        });
        //modelBuilder.Entity<Customer>(entity =>
        //{
        //    entity.ToTable("Customer", "SalesLT");

        //    entity.Property(e => e.Id).ValueGeneratedNever();

        //    entity.Property(e => e.FirstName).HasMaxLength(40);

        //    entity.Property(e => e.LastName).HasMaxLength(40);

        //    entity.Property(e => e.Phone).HasMaxLength(20);
        //}
        //);
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
