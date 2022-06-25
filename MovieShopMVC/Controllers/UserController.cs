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
            public UserController(ICurrentLogedInUser currentLogedInUser)
        {
                _currentLogedInUser = currentLogedInUser;
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
        public async Task<IActionResult> AddReview()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddFavorite()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BuyMovie()
        {
            return View();
        }

    }


}
