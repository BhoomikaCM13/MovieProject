using CoreBL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CoreEntity;


namespace MovieCoreWebAPI.Controllers
{
    [Route("api/[controller]")] //localhost:11779/api/Movie/GetMovies
    [ApiController]
    public class MovieController : ControllerBase
    {
        private MovieService _movieService;
        public MovieController(MovieService movieService)
        {
            _movieService = movieService;
        }
        [HttpGet("GetMovies")] //Attributes-the one above a method or property is called attribute
        public IEnumerable<Movie> GetMovies()
        {
            return _movieService.GetMovies();
        }
        [HttpPost("AddMovie")]
        public IActionResult AddMovie([FromBody] Movie movie)
        {
            _movieService.AddMovie(movie);
            return Ok("Movie created successfully!!");
        }
        [HttpDelete("DeletMovie")]
        public IActionResult DeleteMovie(int id)
        {
            _movieService.DeleteMovie(id);
            return Ok("Movie deleted Successfully!!");
        }
        [HttpPut("UpdateMovie")]
        public IActionResult UpdateMovie([FromBody] Movie movie)
        {
            _movieService.UpdateMovie(movie);
            return Ok("Movie updatesd succesfully!!");
        }
        [HttpGet("GetMovieById")] 
        public Movie GetMovieById(int id)
        {
            return _movieService.GetMovieById(id);
        }

    }
}
