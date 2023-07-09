using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos;

public class CreateMovieDto
{
    [Required]
    public string Title { get; set; }
    [Required]
    public string Gender { get; set; }
    [Required]
    public int Duration { get; set; }
}
