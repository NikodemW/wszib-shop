﻿using System;
using System.Collections.Generic;
using System.Text;
using Shop.Core.Domain;
using Microsoft.Extensions.Caching.Memory;

namespace Shop.Core.Services
{
    public class CartManager : ICartManager
    {
        private readonly IMemoryCache _cache;
        public CartManager(IMemoryCache cache)
        {
            _cache = cache;
        }
        public Cart Get(Guid userId) => _cache.Get<Cart>(GetCartKey(userId));


        public void Set(Guid userId, Cart cart) => _cache.Set(GetCartKey(userId), cart);

        public void Delete(Guid userId) => _cache.Remove(GetCartKey(userId));

        private string GetCartKey(Guid userId) => $"{userId}:cart";


    }
}
