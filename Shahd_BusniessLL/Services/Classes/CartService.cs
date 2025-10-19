using Azure.Core;
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
    public class CartService : ICartService
    {
        private readonly ICartRepo _cartRepo;

        public  CartService(ICartRepo cartRepo)
        {
            _cartRepo = cartRepo;
        }
        public async Task<bool> AddToCartAsync(CartRequest request, string UserId)
        {
            var newItem = new Cart
            {
                ProductId = request.ProductId,
                UserId = UserId,
                Count = 1
            };

            return await _cartRepo.AddAsync(newItem) >0 ;
        }

        public async Task<CartsummaryResponse> CartsummaryResponseAsync(string UserId)
        {
            var cartItems =await _cartRepo.GetUserCartAsync(UserId);

            var response = new CartsummaryResponse
            {
                Items = cartItems.Select(ci => new CartResponse
                {
                    ProductId = ci.ProductId,
                    ProductName = ci.Product.Name,
                    Count = ci.Count,
                    Price = ci.Product.Price,
                }).ToList()
            };

            return response;
        }

        public async Task<bool> ClearCartAsync(string UserId)
        {
           return await _cartRepo.ClearCartAsync( UserId);
        }
    }
}
