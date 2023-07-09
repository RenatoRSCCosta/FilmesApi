using FilmesApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MovieController : ControllerBase
{
    private static List<Movie> _movies = new List<Movie>();
    private static int id = 0;

    [HttpPost]
    public IActionResult Add([FromBody] Movie movie)
    {
        movie.Id = id++;
        _movies.Add(movie);
        return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
    }

    [HttpGet]
    public IEnumerable<Movie> GetAllMovies()
    {
        return _movies;
    }

    [HttpGet("{id}")]
    public IActionResult GetMovieById([FromQuery] int id)
    {
        var movie =  _movies.FirstOrDefault(movie => movie.Id == id);
        if(movie == null)
        {
            return NotFound();
        }
        return Ok(movie);
    }
}
