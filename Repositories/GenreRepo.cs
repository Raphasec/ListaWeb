using Aula14.Data;
using Aula14.Models;

namespace Aula14.Repositories;

public class GenreRepo : IGenreRepo
{
    private DataContext _db;
    public GenreRepo(DataContext db)
    {
        _db = db;
    }

    public List<Genre> GetAllGenres()
    {
        var genres = _db.Genres.OrderBy(g => g.IdGenre).ToList();
        return genres;
    }

    public Genre GetGenreById(int id)
    {
        var genre = _db.Genres.Find(id);
        return genre;
    }
}