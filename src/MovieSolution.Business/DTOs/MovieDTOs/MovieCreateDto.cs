using FluentValidation;

namespace MovieSolution.Business.DTOs.MovieDTOs;

public class MovieCreateDto
{
    public int GenreId { get; set; }
    public string Name { get; set; }
    public string Desc { get; set; }
    public double SalePrice { get; set; }
    public double CostPrice { get; set; }
}


