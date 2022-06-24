using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class UserController : Controller
    {
        //all these action methods should only be excuted when user is loged in.
        [HttpGet]
        public async Task<IActionResult> Purchase()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Favorite()
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
