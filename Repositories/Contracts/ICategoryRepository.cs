using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Repositories.Contracts
{
    public interface ICategoryRepository : IRepositoryBase<Category>
    {
        void CreateCategory(Category category);
        Category? GetById(int id, bool trackChanges);
        void DeleteCategory(Category category);

    }
}
