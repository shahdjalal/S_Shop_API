using Azure.Core;
using Microsoft.AspNetCore.Http;
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
  public  interface IProductService : IGenericService<ProductRequest, ProductResponse, Product>
    {
     Task<int> CreateProduct(ProductRequest request);

        Task<List<ProductResponse>> GetAllProducts(HttpRequest request, bool onlyActive = false, int pageNumber = 1, int pageSize = 5);
    }
}
