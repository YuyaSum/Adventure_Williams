using DBProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace Adventure_Williams.Controllers
{
    public class CustomerController : Controller
    {
        private Repository repository;
        public CustomerController(Repository context) {
            repository = context;
        }
        public IActionResult Index()
        {
            List<Customer> customers = (List<Customer>)repository.AllCustomers();
            return View(customers);
        }
    }
}
