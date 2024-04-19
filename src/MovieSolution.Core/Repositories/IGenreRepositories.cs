using MovieSolution.Core.Entities;
using System.Linq.Expressions;

namespace MovieSolution.Core.Repositories;

public interface IGenreRepositories : IGenericRepositories<Genre>
{
    Task<bool> IsExist(Expression<Func<Genre, bool>> expression);
}
