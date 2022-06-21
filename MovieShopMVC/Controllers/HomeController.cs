using ApplicationCore.Contract.Services;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Models;
using System.Diagnostics;

namespace MovieShopMVC.Controllers
{
    public class HomeController : Controller
    //inherite from Controller, then being controller. without inherite, it is a  normal class. 
    {
        private readonly ILogger<HomeController> _logger;
        //readonly can only be modified in constructor. not in methods.

        //private readonly MovieService _movieService;       //refactor only by initiate class in constructor

        //best practice is using DI
        //depend on higher level abstrction
        private readonly IMovieService _movieService;
        public HomeController(ILogger<HomeController> logger, IMovieService movieService) 
            //this is the constructor
        {
            _logger = logger; //default parameter
            //_movieService= new MovieService();      //refactor only by initiate class in constructor, not DI

            //DI: to totally get rid of new className() initiate way, totally using higher level interface
            _movieService = movieService; 
            //***Important: put interface - (current implementation class) relations in service container in Program.cs file
            //Or, you will got Unable to resolve service Exception!!!!
        }


        [HttpGet] //default is Get request.
        public async Task<IActionResult> Index()  //action
        {
            //home page
            //top 30 movies ->Movie Seivice
            //instance of MovieService Class
            //var movieService = new MovieService(); //tight coupling. not good!
            //var movies = movieService.GetTopGrossingMovies();

            //refactor the upper code by DI
            var movies = await _movieService.GetTopGrossingMovies();

            //passing the data from Controller/action method to the view
            //check definition, parameter: objects model, object is a top class, any data type can be one kind sub object.
            return View(movies);  //go to Views and find same name cshtml file under the folder with the same name as the controler.
        }

        [HttpGet]
        public IActionResult TopRatedMovies() { 

            //call the movie service
            //movie service will call movie repository
            //movie repository will call the database to get the data
            return View(); 
        }

        public IActionResult Privacy()  //action
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        
        public IActionResult Error() //action
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}