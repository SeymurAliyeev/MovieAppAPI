using MovieSolution.Core.Entities;
using System.Linq.Expressions;

namespace MovieSolution.Core.Repositories;

public interface IGenreRepositories
{
    Task InsertAsync(Genre genre);
    void Delete(Genre genre);
    Task<Genre> GetByIdAsync(int id);
    Task<List<Genre>> GetAllAsync(Expression <Func<Genre,bool>> expression = null, params string[] includes);
    Task<Genre> GetAsync(Expression <Func<Genre,bool>> expression = null, params string[] includes);
    Task<int> CommitAsync();
}
