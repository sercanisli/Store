using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entities.DTOs;
using Entities.Models;
using Entities.RequestParameters;
using Repositories.Contracts;
using Services.Contracts;

namespace Services.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public ProductManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
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

        public void CreateProduct(ProductDTOForInsertion productDtoForInsertion)
        {
            Product product = _mapper.Map<Product>(productDtoForInsertion);
            _manager.Products.Create(product);
            _manager.Save();
        }

        public void Update(ProductDTOForUpdate productDtoForUpdate)
        {
            var entity = _mapper.Map<Product>(productDtoForUpdate);    
            _manager.Products.UpdateOneProduct(entity);
            _manager.Save(); 
        }

        public void DeleteProduct(int id)
        {
            Product product = GetById(id, false);
            if (product!=null)
            {
             _manager.Products.DeleteProduct(product);
             _manager.Save();
            }
        }

        public ProductDTOForUpdate GetByIdForUpdate(int id, bool trackChanges)
        {
            var product = GetById(id, trackChanges);
            var productDTOForUpdate = _mapper.Map<ProductDTOForUpdate>(product);
            return productDTOForUpdate;
        }

        public IEnumerable<Product> GetShowcaseProducts(bool trackChanges)
        {
            var products = _manager.Products.GetShowcaseProducts(trackChanges);
            return products;
        }

        public IEnumerable<Product> GetAllProductsWithDetails(ProductRequestParameters productRequestParameters)
        {
            return _manager.Products.GetAllProductsWithDetails(productRequestParameters);
        }
    }
}
