using ApplicationCore.Contract.Repository;
using ApplicationCore.Contract.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IMovieRepository _movieRepository; //DI
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IReviewRepository _reviewRepository;
        public UserService(IMovieRepository movieRepository, IPurchaseRepository purchaseRepository, IReviewRepository reviewRepository)
        {
            _movieRepository = movieRepository;     //DI
            _purchaseRepository = purchaseRepository;
            _reviewRepository = reviewRepository;
        }

        public Task AddFavorite(FavoriteRequestModel favoriteRequest)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFavorite(FavoriteRequestModel favoriteRequest)
        {
            throw new NotImplementedException();
        }

        public Task FavoriteExists(int id, int movieId)
        {
            throw new NotImplementedException();
        }

        public Task GetAllFavoritesForUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddMovieReview(ReviewModel reviewRequest)
        {
            var newReview = new Review
            {
                MovieId = reviewRequest.MovieId,
                UserId = reviewRequest.UserId,
                Rating = reviewRequest.Rating,
                ReviewText = reviewRequest.ReviewText,
            };

            var savedReview = await _reviewRepository.Add(newReview); //add Entity Type
            if (savedReview.MovieId>0)
            {
                return true;
            }
            return false;
        }

        public Task DeleteMovieReview(int userId, int movieId)
        {
            throw new NotImplementedException();
        }

        public Task GetAllReviewsByUser(int id)
        {
            throw new NotImplementedException();
        }


        public Task UpdateMovieReview(ReviewModel reviewRequest)
        {
            throw new NotImplementedException();
        }

        public Task GetAllPurchasesForUser(int id)
        {
            throw new NotImplementedException();
        }


        public Task GetPurchasesDetails(int userId, int movieId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsMoviePurchased(int movieId, int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> PurchaseMovie(int movieId, int userId)
        {
            //add new purchase into Purchase Table
            var movieDetails = await _movieRepository.GetById(movieId);
            var newPurchase = new Purchase
            {
                MovieId = movieId,
                UserId = userId,
                TotalPrice = (decimal)movieDetails.Price,
                PurchaseDateTime = DateTime.Now,
            };
            var savedPurchase = await _purchaseRepository.Add(newPurchase);
            if (savedPurchase.Id > 0)
            {
                return true;
            }
            return false;

        }

    }
}
