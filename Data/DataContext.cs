using Aula14.Models;
using Microsoft.EntityFrameworkCore;

namespace Aula14.Data;

public class DataContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Genre> Genres { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }
}