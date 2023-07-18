using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;
using Entities.Models;

namespace Services.Contracts
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts(bool trackChanges);
        Product? GetById(int id, bool trackChanges);
        void CreateProduct(ProductDTOForInsertion productDtoForInsertion);
        void Update(ProductDTOForUpdate productDtoForUpdate);
        void DeleteProduct(int id);
        ProductDTOForUpdate GetByIdForUpdate(int id, bool trackChanges);
    }
}
