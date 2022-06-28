using ApplicationCore.Contract.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterModel userRegisterModel)
        {
            //[fromBody] is from http request body, user input data.
            var user = await _accountService.RegisterUser(userRegisterModel);

            return Ok(user);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginModel userLoginModel)  //overLoading, modal binding
        {
            var user = await _accountService.ValidateUser(userLoginModel);
            if (user == null)
            {
                return NotFound(new { errorMessage = "No User found" });
            }
            return Ok(user);
        }
    }
}
