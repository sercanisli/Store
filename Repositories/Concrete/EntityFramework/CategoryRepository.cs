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
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateCategory(Category category) => Create(category);

        public void DeleteCategory(Category category) => Remove(category);

        public Category? GetById(int id, bool trackChanges)
        {
            return FindByCondition(c => c.Id == id, false);
        }
    }
}
