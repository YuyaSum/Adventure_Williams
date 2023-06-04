using DBProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace Williams_Adventure.Controllers
{
    public class ProductsController : Controller
    {
        private Repository _repository;
        public ProductsController(Repository context)
        {
            _repository = context;
        }

        public IActionResult Products()
        {
            List<Products> products = (List<Products>)_repository.GetAllProductsandPrices();
            return View(products);
        }
    }
}
