using Shahd_DataAccessL.Data;
using Shahd_DataAccessL.Models;
using Shahd_DataAccessL.Repositories.Interfaces;


namespace Shahd_DataAccessL.Repositories.Classes
{
    public class CartRepo : ICartRepo
    {
        private readonly ApplicationDbContext _context;

        public CartRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public int Add(Cart cart)
        {
           _context.Carts.Add(cart);
            return _context.SaveChanges();
        }
    }
}
