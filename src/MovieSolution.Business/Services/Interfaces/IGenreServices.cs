using MovieSolution.Core.Entities;

namespace MovieSolution.Business.Services.Interfaces;

public interface IGenreServices
{
    Task<Genre> CreateAsync(Genre genre);
    Task<List<Genre>> ShowAllAsync();
    Task<Genre> ShowByIdAsync(int id);
    Task<Genre> ShowOneAsync();
    void Delete(Genre genre);
}
