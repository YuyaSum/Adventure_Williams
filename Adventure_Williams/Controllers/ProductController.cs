using DBProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace Williams_Adventure.Controllers
{
    public class ProductController : Controller
    {
        private Repository _repository;
        public ProductController(Repository context)
        {
            _repository = context;
        }

        public IActionResult Index()
        {
            List<Products> products = (List<Products>)_repository.GetAllProductsandPrices();
            return View(products);
        }
    }
}
