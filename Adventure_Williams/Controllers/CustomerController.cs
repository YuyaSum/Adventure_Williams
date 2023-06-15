using DBProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace Adventure_Williams.Controllers
{
    public class CustomerController : Controller
    {
        private Repository _repo;
        public CustomerController(Repository context) {
            _repo = context;
        }
        public IActionResult Index()
        {
            List<Customer> customers = (List<Customer>)_repo.AllCustomers();
            return View(customers);
        }
        public IActionResult Create()
        {
            return View();
        }
        //Get
        public IActionResult Edit(int id) 
        {
            var customer = _repo.GetCustomer(id);
            return View(customer);
        }

        //[HttpPost, ActionName("Edit")]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit(Customer customer)
        //{
        //    if (customer != null)
        //    {
        //        return NotFound();
        //    }


        //    return RedirectToAction(nameof(Index));
        //}

        public IActionResult Delete(int id)
        {
            var customer = _repo.GetCustomer(id);
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
            var customer = _repo.GetCustomer(id);
            _repo.DeleteCust(customer);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Orders(int id) 
        {
            var customerOrderView = new CustomerOrderView {
                customer = _repo.GetCustomer(id),
                orders = _repo.GetOrders(id).ToList()
            };
            return View(customerOrderView);
        }
    }
}
