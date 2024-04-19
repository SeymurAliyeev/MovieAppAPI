using Microsoft.EntityFrameworkCore;
using MovieSolution.Business.CustomExceptions.CommonExceptions;
using MovieSolution.Business.DTOs.GenreDTOs;
using MovieSolution.Business.Services.Interfaces;
using MovieSolution.Core.Entities;
using MovieSolution.Core.Repositories;
using MovieSolution.Data.Repositories;

namespace MovieSolution.Business.Services.Implementations
{
    public class GenreService : IGenreServices
    {
        private readonly IGenreRepositories _genreRepository;

        public GenreService(IGenreRepositories genreRepositories)
        {
            _genreRepository = genreRepositories;
        }
        public async Task<Genre> CreateAsync(GenreCreateDto dto)
        {
            if(await _genreRepository.Table.AnyAsync(g => g.Name == dto.Name))
            {
                throw new AlreadyExistException("Genre name is already exist!");
            }

            Genre genre = new Genre()
            {
                Name = dto.Name,
                IsDeleted = false,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            };
            await _genreRepository.InsertAsync(genre);
            await _genreRepository.CommitAsync();

            return genre;
        }

        public void Delete(Genre genre)
        {
            _genreRepository.Delete(genre);
            _genreRepository.CommitAsync();
        }

        public async Task<List<Genre>> ShowAllAsync()
        {
            return await _genreRepository.GetAllAsync();
        }

        public async Task<Genre> ShowByIdAsync(int id)
        {
            return await _genreRepository.GetByIdAsync(id);
        }

        public async Task<Genre> ShowOneAsync()
        {
            return await _genreRepository.GetAsync();
        }
    }
}
