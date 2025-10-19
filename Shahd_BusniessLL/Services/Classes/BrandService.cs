using Mapster;
using Shahd_BusniessLL.Services.Interfaces;
using Shahd_DataAccessL.DTO.Requests;
using Shahd_DataAccessL.DTO.Responses;
using Shahd_DataAccessL.Models;
using Shahd_DataAccessL.Repositories.Interfaces;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shahd_BusniessLL.Services.Classes
{
    public class BrandService : GenericService<BrandRequest, BrandResponse, Brand>, IBrandService
    {
        private readonly IBrandRepo _brandRepository;
        private readonly IFileService _fileService;

        public BrandService(IBrandRepo BrandRepository,IFileService fileService) : base(BrandRepository)
        {
            _brandRepository = BrandRepository;
            _fileService = fileService;
        }

        public async Task<int> CreateFile(BrandRequest request)
        {
            var entity = request.Adapt<Brand>();
            entity.CreatedAt = DateTime.UtcNow;

            if (request.Image != null)
            {
                var imagePath = await _fileService.UploadAsync(request.Image);
                entity.Image = imagePath;
            }

            return _brandRepository.Add(entity);
        }

    }
}
