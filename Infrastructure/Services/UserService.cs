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
        private readonly IFavoriteRepository _favoriteRepository;

        public UserService(IMovieRepository movieRepository, IPurchaseRepository purchaseRepository, IReviewRepository reviewRepository, IFavoriteRepository favoriteRepository)
        {
            _movieRepository = movieRepository;     //DI
            _purchaseRepository = purchaseRepository;
            _reviewRepository = reviewRepository;
            _favoriteRepository = favoriteRepository;
        }

        public async Task<bool> AddFavorite(int movieId, int userId)
        {
            //add new favorite into Favorite Table
            var newFavorite = new Favorite
            {
                MovieId = movieId,
                UserId = userId,
            };
            var savedFavorite = await _favoriteRepository.Add(newFavorite);
            if (savedFavorite.Id > 0)
            {
                return true;
            }
            return false;
        }

        public Task RemoveFavorite(FavoriteRequestModel favoriteRequest)
        {
            throw new NotImplementedException();
        }

        public Task FavoriteExists(int id, int movieId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MovieCardModel>> GetAllFavoritesForUser(int userId)
        {
            var movieFavo = await _favoriteRepository.GetMoviesByUserId(userId); //list of movie entity

            var movieCards = new List<MovieCardModel>();
            foreach (var movieEntity in movieFavo)
            {
                movieCards.Add(new MovieCardModel { Id = movieEntity.Id, PosterUrl = movieEntity.PosterUrl, Title = movieEntity.Title });

            }

            return movieCards;

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

        public async Task<List<MovieCardModel>> GetAllPurchasesForUser(int userId)
        {
            var moviePurchased = await _purchaseRepository.GetMoviesByUserId(userId); //list of movie entity
            
            var movieCards = new List<MovieCardModel>();
            foreach (var movieEntity in moviePurchased)
            {
                movieCards.Add(new MovieCardModel { Id = movieEntity.Id, PosterUrl = movieEntity.PosterUrl, Title = movieEntity.Title });

            }

            return movieCards;
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
