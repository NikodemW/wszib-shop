using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Core.Domain
{
    class Order
    {
        public Guid UserId { get; }
        public IEnumerable<OrderItem> Items { get; }
        public decimal TotalPrice { get; }
        public DateTime CreatedAt { get; }

        public Order(User user, Cart cart)
        {
            UserId = user.Id;
            Items = cart.Items.Select(x => new OrderItem(x));
            TotalPrice = cart.TotalPrice;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
