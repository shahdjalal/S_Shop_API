using Shahd_DataAccessL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shahd_DataAccessL.Repositories.Interfaces
{
    public interface IReviewRepo
    {
        Task<bool> HasUserReviewProduct(string userId , int productId);

        Task AddReviewAsync(Review request, string userId);
    }
}
