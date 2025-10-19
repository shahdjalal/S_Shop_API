using Shahd_BusniessLL.Services.Interfaces;
using Shahd_DataAccessL.Models;
using Shahd_DataAccessL.Repositories.Interfaces;


namespace Shahd_BusniessLL.Services.Classes
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepo _orderRepo;

        public OrderService(IOrderRepo orderRepo)
        {
            _orderRepo = orderRepo;
        }
        public async Task<Order?> AddAsync(Order order)
        {
            return await _orderRepo.AddAsync(order);
        }

        public async Task<bool> ChangestatusAsync(int orderId, OrderStatusEnum newStatus)
        {
            return await  _orderRepo.ChangestatusAsync(orderId,newStatus);
        }

        public async Task<List<Order>> GetAllWithUserAsync(string UserId)
        {
            return await _orderRepo.GetAllWithUserAsync(UserId);
        }

        public async Task<List<Order>> GetByStatusAsync(OrderStatusEnum status)
        {
            return await _orderRepo.GetByStatusAsync(status);
        }

        public async Task<List<Order>> GetOrderByUserAsync(string UserId)
        {
            return await _orderRepo.GetOrderByUserAsync(UserId);
        }

        public async Task<Order?> GetUserByOrderAsync(int orderId)
        {
            return await _orderRepo.GetUserByOrderAsync(orderId);
        }
    }
}
