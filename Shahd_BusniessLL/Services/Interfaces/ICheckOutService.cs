using Microsoft.AspNetCore.Http;
using Shahd_DataAccessL.DTO.Requests;
using Shahd_DataAccessL.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shahd_BusniessLL.Services.Interfaces
{
    public interface ICheckOutService
    {
        Task<CheckOutResponse> processPaymentasync(CheckOutRequest request,string UserId, HttpRequest httpRequest);
        Task<bool> handlePaymentasync(int orderId);


    }
}
