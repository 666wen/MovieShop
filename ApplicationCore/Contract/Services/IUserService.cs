using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contract.Services
{
    public interface IUserService
    {
        Task<bool> PurchaseMovie(int movieId, int userId);
        Task<bool> IsMoviePurchased(int movieId, int userId);
        Task GetAllPurchasesForUser(int id);
        Task GetPurchasesDetails(int userId, int movieId);
        Task AddFavorite(FavoriteRequestModel favoriteRequest);
        Task RemoveFavorite(FavoriteRequestModel favoriteRequest);
        Task FavoriteExists(int id, int movieId);
        Task GetAllFavoritesForUser(int id);
        Task<bool> AddMovieReview(ReviewModel reviewRequest);
        Task UpdateMovieReview(ReviewModel reviewRequest);
        Task DeleteMovieReview(int userId, int movieId);
        Task GetAllReviewsByUser(int id);
    }
}
