using Microsoft.EntityFrameworkCore;
using Shahd_DataAccessL.Data;
using Shahd_DataAccessL.Models;
using Shahd_DataAccessL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shahd_DataAccessL.Repositories.Classes
{
    public class OrderRepo : IOrderRepo
    {
        private readonly ApplicationDbContext _context;

        public OrderRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Order?> AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return order;

        }

        public async Task<Order?> GetUserByOrderAsync(int orderId)
        {
            return await _context.Orders.Include(o => o.User).FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public async Task<List<Order>> GetAllWithUserAsync(string UserId)
        {
            return await _context.Orders.Where(o => o.UserId == UserId).ToListAsync();
        }

        public async Task<List<Order>> GetByStatusAsync(OrderStatusEnum status)
        {
            return await _context.Orders.Where(o => o.Status == status)
                .OrderByDescending(o => o.OrderDate).ToListAsync();
        }


        public async Task<List<Order>> GetOrderByUserAsync(string UserId)
        {
            return await _context.Orders.Include(o => o.User)
                .OrderByDescending(o => o.OrderDate).ToListAsync();
        }

        public async Task<bool> ChangestatusAsync(int orderId, OrderStatusEnum newStatus)
        {
            var order = await _context.Orders.FindAsync(orderId);

            if (order == null) { return false; }

            order.Status = newStatus;

            var result = await _context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool>  UserHasApprovedOrderForProduct(string UserId, int ProductId)
            {

            return await _context.Orders.Include(o => o.OrderItems)
                .AnyAsync(e => e.UserId == UserId && e.Status ==OrderStatusEnum.Approved
                && e.OrderItems.Any(oi => oi.ProductId == ProductId));
}
    }
}
