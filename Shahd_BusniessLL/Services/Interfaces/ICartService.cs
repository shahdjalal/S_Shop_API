using Shahd_DataAccessL.DTO.Requests;
using Shahd_DataAccessL.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shahd_BusniessLL.Services.Interfaces
{
    public interface ICartService
    {
      Task<bool>  AddToCartAsync(CartRequest request, string UserId);
        Task<CartsummaryResponse> CartsummaryResponseAsync(string UserId);
        Task <bool> ClearCartAsync(string UserId);
    }
}
