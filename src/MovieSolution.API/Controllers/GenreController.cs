using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MovieSolution.Business.Services.Interfaces;
using MovieSolution.Core.Entities;

namespace MovieSolution.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GenreController : ControllerBase
{
    private readonly IGenreServices _genreServices;

    public GenreController(IGenreServices genreServices)
    {
        _genreServices = genreServices;
    }


    [HttpPost ("")]
    public async Task<IActionResult> Create(Genre genre)
    {
        return Ok(await _genreServices.CreateAsync(genre));
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _genreServices.ShowAllAsync());
    }
}
