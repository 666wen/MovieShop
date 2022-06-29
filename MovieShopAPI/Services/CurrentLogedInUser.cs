using System.Security.Claims;

namespace MovieShopAPI.Services
{
    public class CurrentLogedInUser : ICurrentLogedInUser
    {
        //get information from HttpContext Claim, this is needed for all pages that need authorization
        //To access HttpContext inside a reular C# class, we need to inject IHttpAccessor
        private readonly IHttpContextAccessor _contextAccessor;
        public CurrentLogedInUser(IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor;
        }

        public int UserId => Convert.ToInt32(_contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

        public string Email => _contextAccessor.HttpContext.User.Claims.FirstOrDefault(c=> c.Type==ClaimTypes.Email).Value;

        public string FullName => _contextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname).Value + " " + _contextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName).Value;

        public IEnumerable<string> Roles => throw new NotImplementedException();

        public bool IsAuthenticated => _contextAccessor.HttpContext.User.Identity.IsAuthenticated;

    }
}
