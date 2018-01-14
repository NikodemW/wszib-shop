using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Shop.Core.Domain;

namespace Shop.Core.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private static readonly ISet<Product> _products = new HashSet<Product>
        {
            new Product("Latop", "Electronics",3000),
            new Product("Jeans", "Troursers", 150),
            new Product("Hammer", "Tools", 47)
        };

        public Product Get(Guid id)
        => _products.SingleOrDefault(x => x.Id == id);

        public IEnumerable<Product> GetAll()
        => _products;
        public void Add(Product product)
        => _products.Add(product);

        public void Update(Product product)
        {
        }
    }
}
