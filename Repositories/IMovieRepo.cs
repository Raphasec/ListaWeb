using Aula14.Models;

namespace Aula14.Repositories;

public interface IMovieRepo
{
    List<Movie> GetAllMovies();

    Movie GetMovieById(int id);
}