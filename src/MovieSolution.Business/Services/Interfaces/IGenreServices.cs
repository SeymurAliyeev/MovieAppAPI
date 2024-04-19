using MovieSolution.Business.DTOs.GenreDTOs;
using MovieSolution.Core.Entities;

namespace MovieSolution.Business.Services.Interfaces;

public interface IGenreServices
{
    Task<Genre> CreateAsync(GenreCreateDto dto);
    Task<List<Genre>> ShowAllAsync();
    Task<Genre> ShowByIdAsync(int id);
    Task<Genre> ShowOneAsync();
    void Delete(Genre genre);
}
