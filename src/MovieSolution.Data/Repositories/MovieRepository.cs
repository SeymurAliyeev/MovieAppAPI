using MovieSolution.Core.Entities;
using MovieSolution.Core.Repositories;
using MovieSolution.Data.Context;

namespace MovieSolution.Data.Repositories;

public class MovieRepository : GenericRepository<Movie>, IMovieRepositories
{
    public MovieRepository(AppDbContext context) : base(context)
    {
    }
}
