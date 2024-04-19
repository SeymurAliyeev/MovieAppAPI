using Microsoft.EntityFrameworkCore;
using MovieSolution.Business.CustomExceptions.CommonExceptions;
using MovieSolution.Business.DTOs.GenreDTOs;
using MovieSolution.Business.DTOs.MovieDTOs;
using MovieSolution.Business.Services.Interfaces;
using MovieSolution.Core.Entities;
using MovieSolution.Core.Repositories;
using MovieSolution.Data.Repositories;

namespace MovieSolution.Business.Services.Implementations;

public class MovieService : IMovieServices
{
    private readonly IMovieRepositories _movieRepositories;
    private readonly IGenreRepositories _genreRepository;

    public MovieService(IMovieRepositories movieRepositories, IGenreRepositories genreRepository)
    {
        _movieRepositories = movieRepositories;
        _genreRepository = genreRepository;
    }
    public async Task<Movie> CreateAsync(MovieCreateDto dto)
    {
        Movie movie = new Movie()
        {
            Name = dto.Name,
            Desc = dto.Desc,
            CostPrice = dto.CostPrice,
            SalePrice = dto.SalePrice,
            GenreId = dto.GenreId,
            IsDeleted = false,
            CreatedDate = DateTime.UtcNow,
            UpdatedDate = DateTime.UtcNow
        };
        await _movieRepositories.InsertAsync(movie);
        await _movieRepositories.CommitAsync();

        return movie;
    }

    public async void Delete(MovieDeleteDto dto)
    {
    }

    public async Task<IEnumerable<MovieGetAllDto>> ShowAllAsync()
    {
        var datas = await _movieRepositories.GetAllAsync(null, "Genre");

        IEnumerable<MovieGetAllDto> getAllDtos = new List<MovieGetAllDto>() { };

        getAllDtos = datas.Select(m => new MovieGetAllDto()
        {
            Id = m.Id,
            Name = m.Name,
            Desc = m.Desc,
            GenreName = m.Genre.Name
        });


        return getAllDtos;
    }

    public Task<Movie> ShowByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Movie> ShowOneAsync()
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(int id, MoviePutDto movieputDto)
    {
        if(id != movieputDto.Id)
        {
            throw new Exception("Id must be valid!");
        };

        if(await _genreRepository.IsExist(x => x.Id != movieputDto.GenreId))
        {
            throw new NotFoundException("Genre not found!");
        };

        var existData = await _movieRepositories.GetByIdAsync(id);

        existData.Name = movieputDto.Name;
        existData.Desc = movieputDto.Desc;
        existData.CostPrice = movieputDto.CostPrice;
        existData.SalePrice = movieputDto.SalePrice;
        existData.IsDeleted = movieputDto.IsDeleted;
        existData.GenreId = movieputDto.GenreId;
        existData.UpdatedDate = DateTime.UtcNow;

        await _movieRepositories.CommitAsync();
    }
}
