using Shahd_DataAccessL.DTO.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shahd_BusniessLL.Services.Interfaces
{
    public interface ICartService
    {
        bool AddToCart(CartRequest request, string UserId);
    }
}
