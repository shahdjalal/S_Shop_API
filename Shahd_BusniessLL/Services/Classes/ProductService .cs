using Mapster;
using Microsoft.AspNetCore.Http;
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

        public async Task<int> CreateProduct(ProductRequest request)
        {
            var entity = request.Adapt<Product>();
            entity.CreatedAt = DateTime.UtcNow;

            if(request.MainImage != null)
            {
              var imagePath=  await _fileService.UploadAsync(request.MainImage);
                entity.MainImage = imagePath;
            }

            if(request.SubImages != null)
            {
                var subImagesPaths = await _fileService.UploadManyAsync(request.SubImages);
                entity.SubImages = subImagesPaths.Select(img => new ProductImage { ImageName =img}).ToList();
            }

            return _repository.Add(entity);
        }

        public async Task<List<ProductResponse>> GetAllProducts(HttpRequest request,bool onlyActive= false,int pageNumber=1 ,int pageSize=5)
        {

            var products = _repository.GetAllProductsWithImages();

            if (onlyActive)
            {
                products=products.Where(p=> p.Status == Status.Active).ToList();
            }

            var pagedProducts= products.Skip((pageNumber-1) *pageSize).Take(pageSize).ToList();

            return pagedProducts.Select(p => new ProductResponse
            {
                Id = p.Id,
                Name = p.Name,
                Quantity = p.Quantity,
                MainImageURL = $"{request.Scheme}://{request.Host}/images/{p.MainImage}",
                SubImagesUrls = p.SubImages.Select(img => $"{request.Scheme}://{request.Host}/images/{img.ImageName}").ToList(),
                Reviews = p.Reviews.Select(r => new ReviewResponse
                {
                    Id=r.Id,
                    Rate = r.Rate,
                    Comment=r.Comment,
                    FullName=r.User.FullName

                }).ToList()

            }).ToList();
        }
    }
}
