using DBProject.Context;
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

        public void DeleteCust(Customer cust) 
        {
            _context.Customer.Remove(cust);
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
