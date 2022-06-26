using ApplicationCore.Contract.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Services;

namespace MovieShopMVC.Controllers
{
    [Authorize]   //apply on the whole class. look into the httpContext find cookie, decrypt claim and pop into User obj, these method gonna use.
    //If not login successfully, there will be no cookie(claims), no needed inform to excute these methods.
    public class UserController : Controller
    {
        //DI get login User infor from cookie, claim principle
        private readonly ICurrentLogedInUser _currentLogedInUser;
        private readonly IUserService _userService;
            public UserController(ICurrentLogedInUser currentLogedInUser, IUserService userService)
        {
            _currentLogedInUser = currentLogedInUser;
            _userService = userService;
        }


        //all these action methods should only be excuted when user is loged in.
        [HttpGet]
        //before excute the login user's methods. need a code to authorize
        // Authorize Filter is built in , also can write costomed filter.
        public async Task<IActionResult> Purchase()
        {

            //go to database and get all the movies purchased by user, by user id in the http request cookies
            //var cookie = this.HttpContext.Request.Cookies["MovieShopAuthCookie"];
            var userId = _currentLogedInUser.UserId;

            return View();
        }

      

        [HttpGet]
        public async Task<IActionResult> Favorite()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddReview(ReviewModel reviewModel)
        {
            var userId = _currentLogedInUser.UserId;
            reviewModel.UserId = userId;
            var addConfirm = await _userService.AddMovieReview(reviewModel);  


            return View("BuyMovie");
        }
        [HttpPost]
        public async Task<IActionResult> AddFavorite()
        {
            return View();
        }

        [HttpGet]  //Important get or post!!
        public async Task<IActionResult> BuyMovie(int movieId)
        {
            if (!_currentLogedInUser.IsAuthenticated)
            {
                return RedirectToAction("Login");
            }

            var purchaseConfirm= await _userService.PurchaseMovie(movieId, _currentLogedInUser.UserId);
            //return LocalRedirect("~/");

            if (purchaseConfirm)
            {
               return View();
            }
            return RedirectToAction("Details");
            
        }

    }


}
