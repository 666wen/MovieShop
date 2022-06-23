using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel userLoginModel)  //overLoading
        {

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            //show the empty register page when we make a get request.
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterModel userRegisterModel)
        {
            return View();
        }

    }
}
