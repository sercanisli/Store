using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IRepositoryManager _manager;

        public ProductManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public IEnumerable<Product> GetAllProducts(bool trackChanges)
        {
            return _manager.Products.GetAllProducts(trackChanges);
        }

        public Product? GetById(int id, bool trackChanges)
        {
            var product = _manager.Products.GetById(id, trackChanges);
            if (product == null)
            {
                throw new Exception("Product Not Found!");
            }

            return product;
        }

        public void CreateProduct(Product product)
        {
            _manager.Products.Create(product);
            _manager.Save();
        }
    }
}
