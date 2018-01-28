﻿using Shop.Core.Domain;
using Shop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;


namespace Shop.Tests.Reopsitories
{
    public class OrderRepositoryTests
    {
        [Fact]
        public void adding_an_order_should_succeed()
        {
            //Arrange
            IOrderRepository orderRepository = new OrderRepository();
            var cart = new Cart();
            cart.AddProduct(new Product("test", "test", 1));
            var order = new Order(new User("test", "test"), cart);
            
            //Act
            orderRepository.Add(order);

            //Assert
            var expectedOrder = orderRepository.Get(order.Id);
            Assert.Equal(expectedOrder, order);

            var orders = orderRepository.Browse(order.UserId);
            Assert.NotEmpty(orders);
            Assert.Single(orders);
            Assert.Contains(orders, o => o.Id == order.Id);

        }
    }
}
