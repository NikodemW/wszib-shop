using Shop.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Core.Services
{
    public interface ICartManager
    {
        Cart Get(Guid userId);
        void Set(Guid userId, Cart cart);
        void Delete(Guid userId);
    }
}
