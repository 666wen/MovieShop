using ApplicationCore.Contract.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
      
        private readonly IUserService _userService;
        public UserController( IUserService userService)
        {
            _userService = userService;
        }

        //------------------------------Movie----------------------------------

        [HttpGet]
        [Route("purchase-movie")]
        public async Task<IActionResult> BuyMovie(int movieId, int userId)
        {
           
            var purchaseConfirm = await _userService.PurchaseMovie(movieId, userId);

            if (purchaseConfirm)
            {
                return Ok(purchaseConfirm);
            }
            return NotFound(new { errorMessage="Purchase Failed"});
        }

        [HttpGet]
        [Route("purchases")]
        public async Task<IActionResult> Purchase(int userId)
        {
            var purchasedMovie = await _userService.GetAllPurchasesForUser(userId);
            if (purchasedMovie == null)
            {
                return NotFound(new { errorMessage = "No Purchase Found" });
            }
            return Ok(purchasedMovie);
        }

        //-----------------------------Favorite-----------------------------------

        [HttpGet]
        [Route("favorite")]
        public async Task<IActionResult> AddFavorite(int movieId, int userId)
        {

            var favoriteConfirm = await _userService.AddFavorite(movieId, userId);

            if (favoriteConfirm)
            {
                return Ok(favoriteConfirm);
            }
            return NotFound(new { errorMessage = "Add Favorite Failed" });
        }

        [HttpGet]
        [Route("favorites")]
        public async Task<IActionResult> Favorite(int userId)
        {
            var favorMovie = await _userService.GetAllFavoritesForUser(userId);
            if (favorMovie == null)
            {
                return NotFound(new { errorMessage = "No Favorite Found" });
            }
            return Ok(favorMovie);
        }

        [HttpDelete]
        [Route("un-favorite")]
        public async Task<IActionResult> DelFavorite(int movieId, int userId)
        {

            var delFavor = await _userService.RemoveFavorite(movieId, userId);

            if (!delFavor)
            {
                return NotFound(new { errorMessage = "Delete Favorite Failed" });
            }
            return Ok(delFavor);
        }

        [HttpGet] // not write swagger will show 500
        [Route("check-movie-favorite/{movieId}")]
        public async Task<IActionResult> FavoriteExistCheck(int movieId, int userId)
        {
            var checkFavor =await  _userService.FavoriteExists(movieId, userId);
            if (!checkFavor)
            {
                return NotFound(new { errorMessage = "The Movie Not In Your List" });
            }
            return Ok(checkFavor);

        }

        //--------------------------Review--------------------------------

        [HttpPost]
        [Route("add-review")]
        public async Task<IActionResult> AddReview([FromBody] ReviewModel reviewModel, int userId)
        {
      
            reviewModel.UserId = userId;
            var addConfirm = await _userService.AddMovieReview(reviewModel);
            if (addConfirm)
            {
                return Ok(addConfirm);
            }
            return NotFound(new { errorMessage = "Add Review Failed" });
        }

        [HttpDelete]
        [Route("delete-review/{movieId:int}")]
        public async Task<IActionResult> DelReview(int movieId, int userId)
        {

            var delReview = await _userService.DeleteMovieReview(movieId, userId);

            if (!delReview)
            {
                return NotFound(new { errorMessage = "Delete Favorite Failed" });
            }
            return Ok(delReview);
        }

       


    }
}
