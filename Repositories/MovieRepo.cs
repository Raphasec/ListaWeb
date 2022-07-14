using Aula14.Data;
using Aula14.Models;

namespace Aula14.Repositories;

public class MovieRepo : IMovieRepo
{
    private DataContext _db;
    public MovieRepo(DataContext db)
    {
        _db = db;
    }

    public List<Movie> GetAllMovies()
    {
        var movies = _db.Movies.OrderBy(m => m.Title).ToList();
        return movies;
    }

    public Movie GetMovieById(int id)
    {
        var movie = _db.Movies.Find(id);
        return movie;
    }
}