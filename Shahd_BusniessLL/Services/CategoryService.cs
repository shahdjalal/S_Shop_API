using Mapster;
using Shahd_DataAccessL.DTO.Requests;
using Shahd_DataAccessL.DTO.Responses;
using Shahd_DataAccessL.Models;
using Shahd_DataAccessL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shahd_BusniessLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo categoryRepository;

        public CategoryService(ICategoryRepo categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }


        public int CreateCategory(CategoryRequest request)
        {
            var category = request.Adapt<Category>();
            return categoryRepository.Add(category);
        }

        public int DeleteCategory(int id)
        {
            var category = categoryRepository.GetById(id);
            if (category is null) return 0;

            return categoryRepository.Remove(category);
        }

        public IEnumerable<CategoryResponse> GetAllCategories()
        {
            var categories = categoryRepository.GetAll();

            return categories.Adapt<IEnumerable<CategoryResponse>>();


        }

        public CategoryResponse GetCategoryById(int id)
        {
            var category = categoryRepository.GetById(id);
            return category is null ? null : category.Adapt<CategoryResponse>();
        }

        public int updateCategory(int id, CategoryRequest request)
        {
            var category = categoryRepository.GetById(id);

            if (category is null) return 0;

            category.Name = request.Name;
            return categoryRepository.Update(category);

        }

        public bool ToggleStatus(int id)
        {
            var category = categoryRepository.GetById(id);

            if (category is null) return false;

            category.Status = category.Status == Status.Active ? Status.InActive : Status.Active;
          categoryRepository.Update(category);

            return true;
        }
    }
}
