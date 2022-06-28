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
        Task<List<MovieCardModel>> GetAllPurchasesForUser(int userId);
        Task GetPurchasesDetails(int userId, int movieId);
        Task<bool> AddFavorite(int movieId, int userId);
        Task<bool> RemoveFavorite(int movieId, int userId);
        Task<bool> FavoriteExists(int movieId, int userId);
        Task<List<MovieCardModel>> GetAllFavoritesForUser(int userId);
        Task<bool> AddMovieReview(ReviewModel reviewRequest);
        Task UpdateMovieReview(ReviewModel reviewRequest);
        Task<bool> DeleteMovieReview(int userId, int movieId);
        Task GetAllReviewsByUser(int id);
    }
}
