using System.ComponentModel.DataAnnotations;

namespace Aula14.Models;

public class Genre
{
    [Key]
    public int IdGenre { get; set; }
    
    [Required, StringLength(100)]
    public string GenreName { get; set; }
}