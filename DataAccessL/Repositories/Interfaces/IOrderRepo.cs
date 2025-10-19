using Shahd_DataAccessL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shahd_DataAccessL.Repositories.Interfaces
{
    public interface IOrderRepo
    {
        Task<Order?> GetUserByOrderAsync(int orderId);
        Task<Order?> AddAsync(Order order);
        Task<List<Order>> GetByStatusAsync(OrderStatusEnum status);
        Task<List<Order>> GetAllWithUserAsync(string UserId);
        Task<bool> ChangestatusAsync(int orderId, OrderStatusEnum newStatus);

        Task<List<Order>> GetOrderByUserAsync(string UserId);

        Task<bool> UserHasApprovedOrderForProduct(string UserId, int ProductId);
    }
}
