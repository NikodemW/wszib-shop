using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Core.Domain;
using Shop.Web.Models;
using Shop.Core.Repositories;

namespace Shop.Web.Controllers
{
    [Route("products")]
    public class ProductsController : Controller
    {
        private static readonly List<Product> _products = new List<Product>
        {
            new Product("Latop", "Electronics",3000),
            new Product("Jeans", "Troursers", 150),
            new Product("Hammer", "Tools", 47)
        };


        [HttpGet]
        public IActionResult Index()
        {
            var products = _products.Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Category = p.Category,
                Price = p.Price
            });

            return View(products);
        }
        [HttpGet("add")]
        public IActionResult Add()
        {
            var viewModel = new AddProductViewModel();
            return View(viewModel);
        }
        [HttpPost("add")]
        public IActionResult Add(AddProductViewModel viewModel)

        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            _products.Add(new Product(viewModel.Name, viewModel.Category, viewModel.Price));
            return RedirectToAction(nameof(Index));
        }
    }
}