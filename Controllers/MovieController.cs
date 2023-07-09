using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MovieController : ControllerBase
{
    private MovieContext _movieContext;
    private IMapper _mapper;

    public MovieController(MovieContext movieContext, IMapper mapper)
    {
        _movieContext = movieContext;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um filme ao banco de dados
    /// </summary>
    /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult Add(CreateMovieDto movieDto)
    {
        var movie = _mapper.Map<Movie>(movieDto);
        _movieContext.Movies.Add(movie);
        _movieContext.SaveChanges();
        return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
    }

    [HttpGet]
    public IEnumerable<Movie> GetAllMovies()
    {
        return _movieContext.Movies;
    }

    [HttpGet("{id}")]
    public IActionResult GetMovieById(int id)
    {
        var movie = _movieContext.Movies.FirstOrDefault(movie => movie.Id == id);
        if(movie == null)
        {
            return NotFound();
        }
        return Ok(movie);
    }

    [HttpPut]
    public IActionResult UpdateMovie(UpdateMovieDto movieDto, int id)
    {
        var movie = _movieContext.Movies.FirstOrDefault(movie => movie.Id == id);
        if (movie == null) NotFound();
        _mapper.Map(movieDto, movie);
        _movieContext.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMovie(int id)
    {
        var movie = _movieContext.Movies.FirstOrDefault(movie => movie.Id == id);
        if (movie == null) NotFound();
        _movieContext.Remove(movie);
        _movieContext.SaveChanges();
        return NoContent();
    }
}
