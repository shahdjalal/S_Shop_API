using Shahd_DataAccessL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shahd_DataAccessL.Repositories.Interfaces
{
   public interface IProductRepo : IGenericRepository<Product>
    {
       Task DecreaseQuantityAsync(List<(int productId, int quantity)>items);
        List<Product> GetAllProductsWithImages();
    }
}
