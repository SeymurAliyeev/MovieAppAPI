using Microsoft.EntityFrameworkCore;
using MovieSolution.Core.Entities;
using MovieSolution.Data.Configurations;
using System.Runtime.CompilerServices;

namespace MovieSolution.Data.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GenreConfiguration).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Genre> Genres { get; set; }
    public DbSet<Movie> Movies { get; set; }
}
