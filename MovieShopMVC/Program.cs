using ApplicationCore.Contract.Repository;
using ApplicationCore.Contract.Services;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Infrastructure.Repository;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//DI is first class citizen in .Net Core
//older .NET framework DI was not builtin, need rely on 3rd party libraries, autofac, ninja
//DI: put interface - (current implementation class) relations in service container
builder.Services.AddScoped<IMovieService, MovieService>();
//if switch to other implementation, just change this setting
//builder.Services.AddScoped<IMovieService, Test3MovieService>();

builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<ICastRepository, CastRepository>();
builder.Services.AddScoped<ICastService, CastService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IRepository<Genre>, Repository<Genre>>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();

//inject the connection string into DbContext option constructor
//get the connection string from app settings.
builder.Services.AddDbContext<MovieShopDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("MovieShopDbConnection"));
});
//parameter: action delegate


//set Cookie based authentication 
//there are many kind of Authentication: cookie, JWT,
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(
       options =>
       {
           //setting for cookie
           options.Cookie.Name = "MovieShopCookie";
           options.ExpireTimeSpan = TimeSpan.FromHours(2);
           options.LoginPath = "/account/login"; //if authentication not successfully, defaultlly redirect to this page
       }
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
