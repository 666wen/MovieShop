using ApplicationCore.Contract.Repository;
using ApplicationCore.Contract.Services;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Infrastructure.Repository;
using Infrastructure.Services;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MovieShopAPI.Services;
using System.Text;

//using MovieShopAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<ICastRepository, CastRepository>();
builder.Services.AddScoped<ICastService, CastService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IRepository<Genre>, Repository<Genre>>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ICurrentLogedInUser, CurrentLogedInUser>(); //for authorization get token data.
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPurchaseRepository, PurchaseRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IFavoriteRepository, FavoriteRepository>();

//important!!! Or, the HttpContexAccessor can not be use! Inject HttpContext for IHttpContextAccessor interface
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MovieShopDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("MovieShopDbConnection"));
});


// API is gonna use JWT authentication, so that it can look at the incoming request and look for Token and valid it depends on if can get the claims in to HttpContext
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["secretKey"]))
        };
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
// when you get a http request from client/browser
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseMovieShopExceptionMiddleware();
app.UseHttpsRedirection();

// make sure you add Authentication Middleware
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
