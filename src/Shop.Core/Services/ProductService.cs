using System;
using System.Collections.Generic;
using System.Text;
using Shop.Core.DTO;
using Shop.Core.Repositories;
using System.Linq;

namespace Shop.Core.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public IEnumerable<ProductDto> GetAll()
        => _productRepository
            .GetAll()
            .Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Category = p.Category,
                Price = p.Price
            });
        public void Add(string name, string category, decimal price)
        {
            throw new NotImplementedException();
        }


    }
}
