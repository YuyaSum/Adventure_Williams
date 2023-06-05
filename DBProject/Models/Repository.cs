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
    }
}
