using ApplicationCore.Contract.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
            public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel userLoginModel)  //overLoading, modal binding
        {
            var isValidPassword =await _accountService.ValidateUser(userLoginModel);
            if (isValidPassword == true)
            {
                //after login successfully, create a cookie, cookies are always sent from browzer automatically to server
                //inside the cookie we store encrypted information (User claims) that Server can recognize and tell wether user
                //is loged in or not. cookies are in request header??
                //Cookie should have an expairation time, which depends on bussiness requirement.

                //create claim



                return LocalRedirect("~/");
            }
            return View(userLoginModel);
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
            //Model binding
            var User =await _accountService.RegisterUser(userRegisterModel);
            //redirect to login page
            
            return RedirectToAction("Login");
        }

    }
}
