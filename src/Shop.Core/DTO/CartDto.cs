using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Core.DTO
{
     public class CartDto
    {
        public IEnumerable<CartItemDto> Items { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
