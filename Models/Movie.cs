using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aula14.Models;

public class Movie
{
    [Key]
    public int MovieId { get; set; }
    
    [Required, StringLength(70)]
    public string Title { get; set; }

    [Required, StringLength(512)]
    public string Synopsis { get; set; }

    public int Duration { get; set; }
 
    public double Rating { get; set; }

    public int Classification { get; set; }

    [Required, StringLength(50)]
    public Genre Genre { get; set; }

    [ForeignKey("Genre")]
    public int IdGenre { get; set; }
}