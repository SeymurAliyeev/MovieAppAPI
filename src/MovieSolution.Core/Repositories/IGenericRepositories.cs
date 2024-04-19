using Microsoft.EntityFrameworkCore;
using MovieSolution.Core.Entities;
using System.Linq.Expressions;

namespace MovieSolution.Core.Repositories;

public interface IGenericRepositories<TEntity> 
                 where TEntity : BaseEntity, new()
{
    DbSet<TEntity> Table { get; }
    Task InsertAsync(TEntity entity);
    void Delete(TEntity entity);
    Task<TEntity> GetByIdAsync(int id);
    Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression = null, params string[] includes);
    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression = null, params string[] includes);
    Task<int> CommitAsync();
}
