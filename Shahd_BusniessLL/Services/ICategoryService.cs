using Shahd_DataAccessL.DTO.Requests;
using Shahd_DataAccessL.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shahd_BusniessLL.Services
{
   public interface ICategoryService
    {

        int CreateCategory(CategoryRequest request);
        IEnumerable<CategoryResponse> GetAllCategories();
        CategoryResponse? GetCategoryById(int id);
        int updateCategory(int id, CategoryRequest request);

        int DeleteCategory(int id);
        public bool ToggleStatus(int id);
    }
}
