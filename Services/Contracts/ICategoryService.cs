using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;
using Entities.Models;

namespace Services.Contracts
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories (bool trackChanges );
        void CreateCategory(CategoryDTOForInsertion categoryDtoForInsertion);
        Category? GetById(int id, bool trackChanges);

        void DeleteCategory(int id);
    }
}
