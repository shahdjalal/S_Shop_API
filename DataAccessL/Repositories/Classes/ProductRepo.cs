using Microsoft.EntityFrameworkCore;
using Shahd_DataAccessL.Data;
using Shahd_DataAccessL.Models;
using Shahd_DataAccessL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shahd_DataAccessL.Models;
namespace Shahd_DataAccessL.Repositories.Classes
{


    public class ProductRepo : GenericRepository<Product> , IProductRepo
    {

    
        private readonly ApplicationDbContext _context;

        public ProductRepo(ApplicationDbContext context) :base(context)
        {
            _context = context;
        }

        public async Task DecreaseQuantityAsync(List<(int productId, int quantity)> items)
        {

            var productIds=items.Select(i=>i.productId).ToList();
            var products = await _context.Products.Where(p => productIds.Contains(p.Id)).ToListAsync();

            foreach (var product in products) { 
            
                var item=items.First(i=> i.productId == product.Id);
                if (product.Quantity < item.quantity)
            {

                    throw new Exception("Products not enough ");

                  }

                product.Quantity -= item.quantity;

           
            }

            await _context.SaveChangesAsync();

        }

        public List<Product> GetAllProductsWithImages()
        {
            return _context.Products.Include(p => p.SubImages).Include(p=>p.Reviews).ThenInclude(r=>r.User).ToList();
        }







    }
}
