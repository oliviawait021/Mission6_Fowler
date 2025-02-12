using Microsoft.EntityFrameworkCore;
namespace Mission6_Fowler.Models;

public class MovieContext : DbContext
{
    public MovieContext(DbContextOptions<MovieContext> options) : base(options)
    { }

    public DbSet<Form> Movies { get; set; }
    
}