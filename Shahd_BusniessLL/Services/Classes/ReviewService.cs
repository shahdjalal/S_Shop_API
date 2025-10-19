using Mapster;
using Shahd_BusniessLL.Services.Interfaces;
using Shahd_DataAccessL.DTO.Requests;
using Shahd_DataAccessL.Models;
using Shahd_DataAccessL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shahd_BusniessLL.Services.Classes
{
    public class ReviewService : IReviewService
    {
        private readonly IOrderRepo _orderRepo;
        private readonly IReviewRepo _reviewRepo;

        public ReviewService(IOrderRepo orderRepo, IReviewRepo reviewRepo)
        {
            _orderRepo = orderRepo;
            _reviewRepo = reviewRepo;
        }
        public async Task<bool> AddReviewAsync(ReviewRequest reviewRequest, string userId)
        {
          var hasOrder= await _orderRepo.UserHasApprovedOrderForProduct(userId,reviewRequest.ProductId);
        
            if(!hasOrder) return false;

            var alreadyReviews = await _reviewRepo.HasUserReviewProduct( userId, reviewRequest.ProductId);
            if (alreadyReviews) return false;

            var review = reviewRequest.Adapt<Review>();
            await _reviewRepo.AddReviewAsync(review,userId);
            return true;

        }
    }
}
