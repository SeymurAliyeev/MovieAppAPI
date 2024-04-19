using Microsoft.EntityFrameworkCore;
using MovieSolution.Core.Entities;
using MovieSolution.Core.Repositories;
using MovieSolution.Data.Context;
using System.Linq.Expressions;

namespace MovieSolution.Data.Repositories;

public class GenreRepository : GenericRepository<Genre>, IGenreRepositories
{
    public GenreRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<bool> IsExist(Expression<Func<Genre, bool>> expression)
    {
        bool isExistGenre = await Table.AnyAsync(expression);
        return isExistGenre;
    }
}
