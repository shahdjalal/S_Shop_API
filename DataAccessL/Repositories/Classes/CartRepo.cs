using Microsoft.EntityFrameworkCore;
using Shahd_DataAccessL.Data;
using Shahd_DataAccessL.Models;
using Shahd_DataAccessL.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Shahd_DataAccessL.Repositories.Classes
{
    public class CartRepo : ICartRepo
    {
        private readonly ApplicationDbContext _context;

        public CartRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddAsync(Cart cart)
        {
         await  _context.Carts.AddAsync(cart);
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> ClearCartAsync(string UserId)
        {
            var items=_context.Carts.Where(c=>c.UserId == UserId).ToList();
            _context.Carts.RemoveRange(items);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Cart>> GetUserCartAsync(string UserId)
        {
            return await _context.Carts.Include(c =>c.Product).Where(c=>c.UserId == UserId).ToListAsync();
        }
    }
}
