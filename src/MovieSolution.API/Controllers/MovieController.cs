using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieSolution.Business.CustomExceptions.CommonExceptions;
using MovieSolution.Business.DTOs.GenreDTOs;
using MovieSolution.Business.DTOs.MovieDTOs;
using MovieSolution.Business.Services.Implementations;
using MovieSolution.Business.Services.Interfaces;
using MovieSolution.Core.Entities;

namespace MovieSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieServices _movieServices;

        public MovieController(IMovieServices movieServices)
        {
            _movieServices = movieServices;
        }

        [HttpPost("")]
        public async Task<IActionResult> Create(MovieCreateDto dto)
        {
            return Ok(await _movieServices.CreateAsync(dto));
        }

        [HttpGet ("")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _movieServices.ShowAllAsync());
        }

        [HttpDelete("")]
        public void Delete(Movie movie)
        {
            
        }

        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, MoviePutDto moviePutDto)
        {
            try
            {
                await _movieServices.UpdateAsync(id, moviePutDto);
            }
            catch(NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok();
        }
    }
}
