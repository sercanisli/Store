using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Repositories.Concrete.Context;

namespace Repositories.Concrete.EntityFramework
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly RepositoryContext _context;

        public RepositoryManager(RepositoryContext context, IProductRepository productRepository, ICategoryRepository categoryRepository, IOrderRepository orderRepository)
        {
            _context = context;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _orderRepository = orderRepository;
        }

        public IProductRepository Products => _productRepository;

        public ICategoryRepository Category => _categoryRepository;

        public IOrderRepository Order => _orderRepository;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
