﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Core.DTO
{
    public class CartItemDto
    {
        public Guid ProductId { get; set; }
        public string ProductName { get;  set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
