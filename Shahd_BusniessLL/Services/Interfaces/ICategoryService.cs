using Shahd_DataAccessL.DTO.Requests;
using Shahd_DataAccessL.DTO.Responses;
using Shahd_DataAccessL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shahd_BusniessLL.Services.Interfaces
{
   public interface ICategoryService : IGenericService<CategoryRequest, CategoryResponse, Category>
    {

       
    }
}
