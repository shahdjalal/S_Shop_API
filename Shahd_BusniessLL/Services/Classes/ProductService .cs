using Mapster;
using Shahd_BusniessLL.Services.Interfaces;
using Shahd_DataAccessL.DTO.Requests;
using Shahd_DataAccessL.DTO.Responses;
using Shahd_DataAccessL.Models;
using Shahd_DataAccessL.Repositories.Classes;
using Shahd_DataAccessL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shahd_BusniessLL.Services.Classes
{
    public class ProductService : GenericService<ProductRequest, ProductResponse, Product>, IProductService
    {
        private readonly IProductRepo _repository;
        private readonly IFileService _fileService;

        public ProductService(IProductRepo repository , IFileService fileService) : base(repository)
        {
            _repository = repository;
            _fileService = fileService;
        }

        public async Task<int> CreateFile(ProductRequest request)
        {
            var entity = request.Adapt<Product>();
            entity.CreatedAt = DateTime.UtcNow;

            if(request.MainImage != null)
            {
              var imagePath=  await _fileService.UploadAsync(request.MainImage);
                entity.MainImage = imagePath;
            }

            return _repository.Add(entity);
        }
    }
}
