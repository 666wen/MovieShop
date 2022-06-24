using ApplicationCore.Contract.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
            var user =await _accountService.ValidateUser(userLoginModel);
            if (user != null)
            {
                //after login successfully, create a cookie, cookies are always sent from browzer automatically to server
                //inside the cookie we store encrypted information (User claims) that Server can recognize and tell wether user
                //is loged in or not. cookies are in request header??
                //Cookie should have an expairation time, which depends on bussiness requirement.

                //create claim
                var claims = new List<Claim>
                {
                    new Claim( ClaimTypes.Email, userLoginModel.Email),
                    new Claim(ClaimTypes.Surname, user.LastName),
                    new Claim(ClaimTypes.GivenName, user.FirstName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.DateOfBirth, user.DateOfBirth.ToString()), //ToShortDateString()??
                    new Claim("Language", "English"), //customed claim
                    new Claim(ClaimTypes.Country, "USA"),
                };
                //create cookie and cookie will have the above claims information along with expiration time
                //do not store above information in the cookie as plain text, instead encrypt the above information
                //encrypt infor can be decrypt in server

                //first tell ASP.NET application that we are using Cookie based Authentication so that
                //ASP.NET can generate Cookie based on the setting we provide

                //create Identity object that will identify the user with claim
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                //Principle object which is used by ASP.NET to recognize the User
                //create the Cookie with above information
                //HttpContext => Encapsulates your Http Request informaion
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity));

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
