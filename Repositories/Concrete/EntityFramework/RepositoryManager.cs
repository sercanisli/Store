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
        private readonly RepositoryContext _context;

        public RepositoryManager(RepositoryContext context, IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _context = context;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public IProductRepository Products => _productRepository; //buna ulaşılmak istenirse buna git.

        public ICategoryRepository Category => _categoryRepository;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
