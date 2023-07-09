using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models;

public class Movie
{
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Gender { get; set; }
    public int Duration { get; set; }
}
