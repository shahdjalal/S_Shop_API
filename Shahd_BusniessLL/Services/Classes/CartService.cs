using Azure.Core;
using Shahd_BusniessLL.Services.Interfaces;
using Shahd_DataAccessL.DTO.Requests;
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
        public bool AddToCart(CartRequest request, string UserId)
        {
            var newItem = new Cart
            {
                ProuductId = request.ProuductId,
                UserId = UserId,
                Count = 1
            };

            return _cartRepo.Add(newItem) >0 ;
        }
    }
}
