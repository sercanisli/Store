using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entities.DTOs;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public CategoryManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public void CreateCategory(CategoryDTOForInsertion categoryDtoForInsertion)
        {
            Category category = _mapper.Map<Category>(categoryDtoForInsertion);
            _manager.Category.Create(category);
            _manager.Save();
        }

        public void DeleteCategory(int id)
        {
            Category category = GetById(id,false);
            if (category != null)
            {
                _manager.Category.DeleteCategory(category);
                _manager.Save();
            }
        }

        public IEnumerable<Category> GetAllCategories(bool trackChanges)
        {
            return _manager.Category.FindAll(trackChanges);
        }

        public Category? GetById(int id, bool trackChanges)
        {
            var category = _manager.Category.GetById(id, trackChanges);
            if (category == null)
            {
                throw new Exception("Category Not Found!");
            }
            return category;
        }
    }
}
