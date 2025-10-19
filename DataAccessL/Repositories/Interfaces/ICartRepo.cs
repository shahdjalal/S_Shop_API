using Shahd_DataAccessL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shahd_DataAccessL.Repositories.Interfaces
{
   public interface ICartRepo
    {

      Task<int>   AddAsync(Cart cart);
        Task<List<Cart>> GetUserCartAsync(string UserId);
       Task<bool> ClearCartAsync(string UserId);
    }
}
