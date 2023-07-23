using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Entities.RequestParameters;

namespace Repositories.Contracts
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        IQueryable<Product> GetAllProducts(bool trackChanges);
        IQueryable<Product> GetAllProductsWithDetails(ProductRequestParameters productRequestParameters);
        IQueryable<Product> GetShowcaseProducts(bool trackChanges);
        Product? GetById(int id, bool trackChanges);
        void CreateProduct(Product product);
        void DeleteProduct(Product product);
        void UpdateOneProduct(Product entity);
    }
}
