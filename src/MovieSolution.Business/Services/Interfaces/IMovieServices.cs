using MovieSolution.Business.DTOs.GenreDTOs;
using MovieSolution.Business.DTOs.MovieDTOs;
using MovieSolution.Core.Entities;

namespace MovieSolution.Business.Services.Interfaces;

public interface IMovieServices
{
    Task<Movie> CreateAsync(MovieCreateDto dto);
    Task<IEnumerable<MovieGetAllDto>> ShowAllAsync();
    Task<Movie> ShowByIdAsync(int id);
    Task<Movie> ShowOneAsync();
    void Delete(MovieDeleteDto dto);
    Task UpdateAsync(int id, MoviePutDto movieputDto);
}
