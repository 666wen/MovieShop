namespace MovieShopMVC.Services
{
    public interface ICurrentLogedInUser
    {
        int UserId { get; }  //not allowed set its value
        string Email { get; }
        string FullName { get; }

        IEnumerable<string> Roles { get; }

        bool IsAuthenticated { get; }



    }
}
