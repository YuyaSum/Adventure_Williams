using DBProject.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProject.Models
{
    public class Repository
    {
        private AWContext _context;
        public Repository(AWContext context)
        {
            _context = context;
        }
        public IEnumerable<Products> GetAllProductsandPrices()
        {
            List<Products> products = _context.Products.ToList();
            return products;
        }
        public void AddProduct(Products product) 
        {
            _context.Add(product);
            _context.SaveChanges();
        }
        public IEnumerable<Customer> AllCustomers()
        {
            List<Customer> cust = _context.Customer.ToList();
            return cust;
        }
        public Customer GetCustomer(int? id)
        {
            Customer customer = _context.Customer.FirstOrDefault(x => x.Id == id);
            return customer;
        }
        public Products GetProduct(int id) {
            Products product = _context.Products.FirstOrDefault(x => x.Id == id);
            return product;
        }
        public IEnumerable<Order> GetOrders(int id) {

            var test = _context.Orders
                .Join(
                _context.OrderHeader
                .Where(o => o.CustomerID == id),
                oh => oh.SalesOrderID,
                o => o.SalesOrderID,
                (od, o) => od).ToList();
                

            return test;
            
        }
        public CustomerAddress GetCustomerAddress(int? id)
        {
            CustomerAddress address = _context.CustomerAddress.Where(y => y.CustomerID == id).FirstOrDefault();
            return address;
        }

        public void DeleteCust(Customer cust) 
        {
             CustomerAddress custAddress = GetCustomerAddress(cust.Id);
            _context.CustomerAddress.Remove(custAddress);
            _context.SaveChanges();

            _context.Customer.Remove(cust);
            _context.SaveChanges();
        }
        public void SaveCust(Customer cust) 
        {
            _context.SaveChanges();
        }
        public void UpdateProduct(Products product) 
        {
            Products oldProduct = _context.Products.FirstOrDefault(p => p.Id == product.Id);

            if (oldProduct != null)
            {
                oldProduct.Name = product.Name;
                oldProduct.ProductNumber = product.ProductNumber;
                oldProduct.Color = product.Color;
                oldProduct.StandardCost = product.StandardCost;
                oldProduct.ListPrice = product.ListPrice;
                oldProduct.Size = product.Size;
                oldProduct.Weight = product.Weight;
                oldProduct.ProductCategoryID = product.ProductCategoryID;
                oldProduct.ProductModelID = product.ProductModelID;
                oldProduct.SellStartDate = product.SellStartDate;
                oldProduct.SellEndDate = product.SellEndDate;
                oldProduct.DiscontinuedDate = product.DiscontinuedDate;
                oldProduct.ModifiedDate = DateTime.Now;
                
            }
            _context.SaveChanges();
        }
        public void UpdateCustomer(Customer cust) { 
            // Update thingy
        }
        public bool CustomerExists(int id) { 
            return _context.Customer.Any(x => x.Id == id);
        }
    }
}
