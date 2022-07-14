using System.Text;
using Aula14.Data;
using Aula14.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DataContext>(options => 
{
    options.UseSqlite("Data Source=data.db");
});

builder.Services.AddScoped<IMovieRepo, MovieRepo>();
builder.Services.AddScoped<IGenreRepo, GenreRepo>();

var app = builder.Build();


app.MapGet("/", (HttpContext context, IMovieRepo repo, IGenreRepo repo2) => 
{
    context.Response.ContentType = "text/html; charset=utf-8";
    StringBuilder sb = new StringBuilder();
    sb.Append("<html><head>");
    sb.Append("<link rel ='stylesheet' href='https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/css/bootstrap.min.css'/>");
    sb.Append("</head><body>");

    sb.Append("<div class='container'>");
    sb.Append("<h1>Movies</h1>");
    sb.Append("<hr/>");
    sb.Append("<table class='table table-striped'>");
    sb.Append("<thead>");
    sb.Append("<tr><th>Title</th><th>Rating</th><th>Duration(min)</th><th>Genre</th>");
    sb.Append("</thead>");
    sb.Append("<tbody></div>");
    
    //Dynamic content production
    var movies = repo.GetAllMovies();
    foreach(var m in movies)
    {
        var genres = repo2.GetGenreById(m.IdGenre).GenreName;
        sb.Append("<tr>");
        sb.Append($"<td>{m.Title}</td>");
        sb.Append($"<td>{m.Rating}</td>");
        sb.Append($"<td>{m.Duration}</td>");
        sb.Append($"<td>{genres}</td>");
        sb.Append("</tr>");
    }

    sb.Append("</tbody>");
    sb.Append("</table>");
    sb.Append("<a href=/genres>Genre</a>");
    sb.Append("</body></html>");

    return sb.ToString();
});

app.MapGet("/genres", (HttpContext context, IGenreRepo repo) => 
{
    context.Response.ContentType = "text/html; charset=utf-8";
    StringBuilder sb = new StringBuilder();
    sb.Append("<html><head>");
    sb.Append("<link rel ='stylesheet' href='https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/css/bootstrap.min.css'/>");
    sb.Append("</head><body>");

    sb.Append("<div class='container'>");
    sb.Append("<h1>Genres</h1>");
    sb.Append("<hr/>");
    sb.Append("<table class='table table-striped'>");
    sb.Append("<thead>");
    sb.Append("<tr><th>Name</th>");
    sb.Append("</thead>");
    sb.Append("<tbody></div>");
    
    //Dynamic content production
    var genres = repo.GetAllGenres();
    foreach(var g in genres)
    {
        sb.Append("<tr>");
        sb.Append($"<td>{g.GenreName}</td>");
        sb.Append("</tr>");
    }

    sb.Append("</tbody>");
    sb.Append("</table>");
    sb.Append("<a href=/>Movies</a>");
    sb.Append("</body></html>");

    return sb.ToString();
});

app.Run();
