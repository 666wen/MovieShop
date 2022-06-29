using ApplicationCore.Contract.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieShopAPI.Services;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]  //look into claim???
    public class UserController : ControllerBase
    {
        private readonly ICurrentLogedInUser _currentLogedInUser;
        private readonly IUserService _userService;
        public UserController( IUserService userService, ICurrentLogedInUser currentLogedInUser)
        {
            _userService = userService;
            _currentLogedInUser = currentLogedInUser;
        }

        //------------------------------Movie----------------------------------

        [HttpGet]
        [Route("purchase-movie")]
        public async Task<IActionResult> BuyMovie(int movieId)
        {
            // we need to get the userId from the token, using HttpContext
            var userId = _currentLogedInUser.UserId;
            var purchaseConfirm = await _userService.PurchaseMovie(movieId, userId);

            if (purchaseConfirm)
            {
                return Ok(purchaseConfirm);
            }
            return NotFound(new { errorMessage="Purchase Failed"});
        }

        [HttpGet]
        [Route("purchases")]
        public async Task<IActionResult> Purchase()
        {
            // we need to get the userId from the token, using HttpContext
            var userId = _currentLogedInUser.UserId;
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
        public async Task<IActionResult> AddFavorite(int movieId)
        {
            // we need to get the userId from the token, using HttpContext
            var userId = _currentLogedInUser.UserId;

            var favoriteConfirm = await _userService.AddFavorite(movieId, userId);

            if (favoriteConfirm)
            {
                return Ok(favoriteConfirm);
            }
            return NotFound(new { errorMessage = "Add Favorite Failed" });
        }

        [HttpGet]
        [Route("favorites")]
        public async Task<IActionResult> Favorite()
        {
            // we need to get the userId from the token, using HttpContext
            var userId = _currentLogedInUser.UserId;
            var favorMovie = await _userService.GetAllFavoritesForUser(userId);
            if (favorMovie == null)
            {
                return NotFound(new { errorMessage = "No Favorite Found" });
            }
            return Ok(favorMovie);
        }

        [HttpDelete]
        [Route("un-favorite")]
        public async Task<IActionResult> DelFavorite(int movieId)
        {
            // we need to get the userId from the token, using HttpContext
            var userId = _currentLogedInUser.UserId;

            var delFavor = await _userService.RemoveFavorite(movieId, userId);

            if (!delFavor)
            {
                return NotFound(new { errorMessage = "Delete Favorite Failed" });
            }
            return Ok(delFavor);
        }

        [HttpGet] // not write swagger will show 500
        [Route("check-movie-favorite/{movieId}")]
        public async Task<IActionResult> FavoriteExistCheck(int movieId)
        {
            // we need to get the userId from the token, using HttpContext
            var userId = _currentLogedInUser.UserId;
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
        public async Task<IActionResult> AddReview([FromBody] ReviewModel reviewModel)
        {
            // we need to get the userId from the token, using HttpContext
            var userId = _currentLogedInUser.UserId;

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
        public async Task<IActionResult> DelReview(int movieId)
        {
            // we need to get the userId from the token, using HttpContext
            var userId = _currentLogedInUser.UserId;
            var delReview = await _userService.DeleteMovieReview(movieId, userId);

            if (!delReview)
            {
                return NotFound(new { errorMessage = "Delete Favorite Failed" });
            }
            return Ok(delReview);
        }

       


    }
}
