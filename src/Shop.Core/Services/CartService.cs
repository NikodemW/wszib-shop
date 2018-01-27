﻿using System;
using System.Collections.Generic;
using System.Text;
using Shop.Core.DTO;
using Shop.Core.Repositories;
using Microsoft.Extensions.Caching.Memory;
using Shop.Core.Domain;
using AutoMapper;
using Shop.Core.Extensions;

namespace Shop.Core.Services
{
    public class CartService : ICartService
    {
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMemoryCache _cache;
        private readonly IMapper _mapper;
        public CartService(IUserRepository userRepository, IProductRepository productRepository, IMemoryCache cache, IMapper mapper)
        {
            _userRepository = userRepository;
            _productRepository = productRepository;
            _cache = cache;
            _mapper = mapper;


        }
        public CartDto Get(Guid userId)
        {
            var cart = GetCart(userId);

            return cart == null ? null : _mapper.Map<CartDto>(cart);
        }
        public void AddProduct(Guid userId, Guid productId)
             => ExecuteOnCart(userId, cart =>
        {
            var product = _productRepository.Get(productId)
            .FailIfNull($"Product with id: '{productId}' was not found.");
     
            cart.AddProduct(product);

        });
        public void DeleteProduct(Guid userId, Guid productId)
        
            => ExecuteOnCart(userId, cart => cart.DeleteProduct(productId));

        public void Clear(Guid userId)
        
            => ExecuteOnCart(userId, cart => cart.Clear());
        

        public void Create(Guid userId)
        {
            GetCart(userId).FailIfExist($" Cart already exist for user with id: '{userId}'.");

            SetCart(userId, new Cart());
        }

        public void Delete(Guid userId)
        {
            GetCartOrFail(userId);
            _cache.Remove(GetCartKey(userId));
        }

        private void ExecuteOnCart(Guid userId, Action<Cart> action)
        {
            var cart = GetCartOrFail(userId);
            action(cart);
            SetCart(userId, cart);
        }

        private Cart GetCartOrFail(Guid userId)
            => GetCart(userId).FailIfNull($" Cart was not found for user with id: '{userId}'.");


        private Cart GetCart(Guid userId) => _cache.Get<Cart>(GetCartKey(userId));
        private void SetCart(Guid userId, Cart cart) => _cache.Set(GetCartKey(userId), cart);
        private string GetCartKey(Guid userId) => $"{userId}:cart";
    }
}
