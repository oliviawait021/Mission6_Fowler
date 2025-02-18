using Microsoft.EntityFrameworkCore;
namespace Mission6_Fowler.Models;

public class MovieContext : DbContext // create the movie context model 
{
    public MovieContext(DbContextOptions<MovieContext> options) : base(options)
    { }

    public DbSet<Form> Movies { get; set; }
    public DbSet<Categories> Categories { get; set; }
}