using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Repositories.Concrete.Context;
using Repositories.Contracts;

namespace Repositories.Concrete.EntityFramework
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<Product> GetAllProducts(bool trackChanges) => FindAll(trackChanges);

        public Product? GetById(int id, bool trackChanges)
        {
            return FindByCondition(p => p.Id == id, trackChanges);
        }

        public void CreateProduct(Product product) => Create(product);
        public void DeleteProduct(Product product) => Remove(product);
        public void UpdateOneProduct(Product entity) => Update(entity);
    }
}
