using DBProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace Williams_Adventure.Controllers
{
    public class ProductController : Controller
    {
        private Repository _repo;
        public ProductController(Repository context)
        {
            _repo = context;
        }

        public IActionResult Index()
        {
            List<Products> products = (List<Products>)_repo.GetAllProductsandPrices();
            return View(products);
        }
        public IActionResult Create(int id) {
            var products = _repo.GetProduct(id);
            return View(products);
        }
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult CreateConfirmed(Products newProduct)
        {
            //newProduct.SellStartDate = (DateTime)newProduct.SellStartDate;
            //newProduct.SellEndDate = (DateTime)newProduct.SellEndDate;
            newProduct.rowguid = Guid.NewGuid();
            newProduct.ModifiedDate = DateTime.Now;
            _repo.AddProduct(newProduct);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            var products = _repo.GetProduct(id); 
            return View(products);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult EditConfirmed(Products newProduct)
        {
            newProduct.ModifiedDate = DateTime.Now;
            _repo.UpdateProduct(newProduct);
            return RedirectToAction(nameof(Index));
        }
    }
}
