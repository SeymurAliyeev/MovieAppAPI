using Microsoft.Extensions.DependencyInjection;
using MovieSolution.Core.Repositories;
using MovieSolution.Data.Repositories;

namespace MovieSolution.Data;

public static class ServiceRegistration
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IGenreRepositories, GenreRepository>();
        services.AddScoped<IMovieRepositories, MovieRepository>();
    }
}
