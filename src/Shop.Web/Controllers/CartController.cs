using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Shop.Core.Services;
using Shop.Web.Models;
using System;
using System.Linq;

namespace Shop.Web.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Route("cart")]
    public class CartController : BaseController
    {
        private readonly ICartService _catrtService;
        private readonly IMapper _mapper;


        public CartController(ICartService cartService, IMapper mapper)
        {
            _catrtService = cartService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var cart = _catrtService.Get(CurrentUserId);
            var viewModel = _mapper.Map<CartViewModel>(cart);
            return View(viewModel);
        }

        [HttpPost("items/{productId}/add")]
        public IActionResult Add(Guid productId)
        {
            _catrtService.AddProduct(CurrentUserId, productId);
   

            //return Ok();
            return RedirectToAction("Index", "Products");
        }
    }
}