using DBProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace Adventure_Williams.Controllers
{
    public class CustomerController : Controller
    {
        private Repository _context;
        public CustomerController(Repository context) {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Customer> customers = (List<Customer>)_context.AllCustomers();
            return View(customers);
        }
        public IActionResult Create()
        {
            return View();
        }
        //Get
        public IActionResult Edit(int id) 
        {
            var customer = _context.GetCustomer(id);
            return View(customer);
        }

        //[HttpPost, ActionName("Edit")]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit(Customer customer)
        //{
        //    if (customer != null) { 
                
        //    }
            

        //    return View();
        //}

        public IActionResult Delete(int id)
        {
            var customer = _context.GetCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id) 
        {
            var customer = _context.GetCustomer(id);
            _context.DeleteCust(customer);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Orders() 
        { 
            return View(); 
        }
    }
}
