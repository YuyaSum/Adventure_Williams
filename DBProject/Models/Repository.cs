using DBProject.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
        public void AddCustomer(Customer customer)
        {
            _context.Add(customer);
            _context.SaveChanges();
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
        public IEnumerable<Order> GetOrders(int id)
        {
            var orders = _context.Orders
                .Where(o => o.OrderHeader.CustomerID == id)
                .ToList();
            return orders;
        }
        public CustomerAddress GetCustomerAddress(int? id)
        {
            CustomerAddress address = _context.CustomerAddress.Where(y => y.CustomerID == id).FirstOrDefault();
            return address;
        }

        public void DeleteCust(Customer cust) 
        {
             CustomerAddress custAddress = GetCustomerAddress(cust.Id);
            if (custAddress != null) {
                _context.CustomerAddress.Remove(custAddress);
            }
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
            Customer oldCustomer = _context.Customer.FirstOrDefault(p => p.Id == cust.Id);

            if (oldCustomer != null)
            {
                oldCustomer.FirstName = cust.FirstName;
                oldCustomer.MiddleName = cust.MiddleName;
                oldCustomer.LastName = cust.LastName;
                oldCustomer.EmailAddress = cust.EmailAddress;
                oldCustomer.Phone = cust.Phone;
                oldCustomer.ModifiedDate = DateTime.Now;
            }
            _context.SaveChanges();
        }
        public bool CustomerExists(int id) { 
            return _context.Customer.Any(x => x.Id == id);
        }
        
    }
}
