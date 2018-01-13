﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Core.Domain;
using Shop.Web.Models;
using Shop.Core.Repositories;
using Shop.Core.Services;

namespace Shop.Web.Controllers
{
    [Route("products")]
    public class ProductsController : Controller
    {
        //private static readonly List<Product> _products = new List<Product>
        //{
        //    new Product("Latop", "Electronics",3000),
        //    new Product("Jeans", "Troursers", 150),
        //    new Product("Hammer", "Tools", 47)
        //};
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var products = _productService
                .GetAll()
                .Select(p => new ProductViewModel
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
            _productService.Add(viewModel.Name, viewModel.Category, viewModel.Price);
            return RedirectToAction(nameof(Index));
        }
    }
}