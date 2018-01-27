using Shop.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Core.DTO
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public IEnumerable<OrderItem> Items { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
