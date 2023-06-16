using DBProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

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

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult CreateConfirmed(Customer newCustomer, string pass)
        {
            byte[] salt = CreateSalt();
            newCustomer.PasswordHash = HashPassword(pass, salt);
            newCustomer.PasswordSalt = Convert.ToBase64String(salt);
            newCustomer.rowguid = Guid.NewGuid();
            newCustomer.ModifiedDate = DateTime.Now;
            _repo.AddCustomer(newCustomer);
            return RedirectToAction(nameof(Index));
        }
        private static byte[] CreateSalt()
        {
            byte[] bytes = new byte[7];
            using (var rng = new RNGCryptoServiceProvider()) 
            { 
                rng.GetBytes(bytes);
            }
            
            return bytes;
        }
        private static string HashPassword(string pass, byte[] salt) {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(pass);

            byte[] hashedBytes;
            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(passwordBytes, salt, 10000, HashAlgorithmName.SHA256))
            {
                hashedBytes = rfc2898DeriveBytes.GetBytes(32); // Hashed password length set to 32 bytes
            }
            return Convert.ToBase64String(hashedBytes);

        }
        public IActionResult Edit(int id) 
        {
            var customer = _repo.GetCustomer(id);
            return View(customer);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult EditConfirmed(Customer newCustomer)
        {
            _repo.UpdateCustomer(newCustomer);
            return RedirectToAction(nameof(Index));
        }

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
