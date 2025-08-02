using Mapster;
using Shahd_BusniessLL.Services.Interfaces;
using Shahd_DataAccessL.DTO.Requests;
using Shahd_DataAccessL.DTO.Responses;
using Shahd_DataAccessL.Models;
using Shahd_DataAccessL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shahd_BusniessLL.Services.Classes
{
    public class CategoryService : GenericService<CategoryRequest, CategoryResponse, Category> , ICategoryService
    {
     

        public CategoryService(ICategoryRepo categoryRepository):base(categoryRepository)
        {
           
        }


 
    }
}
