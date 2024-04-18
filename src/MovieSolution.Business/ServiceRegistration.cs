using Microsoft.Extensions.DependencyInjection;
using MovieSolution.Business.Services.Implementations;
using MovieSolution.Business.Services.Interfaces;

namespace MovieSolution.Business
{
    public static class ServiceRegistration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IGenreServices, GenreService>();
        }
    }
}
