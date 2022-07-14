using Aula14.Models;

namespace Aula14.Repositories;

public interface IGenreRepo
{
    List<Genre> GetAllGenres();

    Genre GetGenreById(int id);
}