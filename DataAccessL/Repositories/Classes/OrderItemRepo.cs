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
    public class OrderItemRepo : IOrderItemRepo
    {
        private readonly ApplicationDbContext _context;

        public OrderItemRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddRangeAsync(List<OrderItems> items)
        {
            await _context.OrderItems.AddRangeAsync(items);
            await _context.SaveChangesAsync();
        }

      
    }
}
