using FluentValidation;
using MovieSolution.Business.DTOs.MovieDTOs;

namespace MovieSolution.Business.DTOValidators.MovieDTOValidators;
public class MovieCreateDtoValidator : AbstractValidator<MovieCreateDto>
{
    public MovieCreateDtoValidator()
    {
        RuleFor(m => m.Name)
            .MaximumLength(255).WithMessage("Name length may not be longer than 255")
            .MinimumLength(1).WithMessage("Name length may not be shorter than 1")
            .NotEmpty().WithMessage("Name may not be empty")
            .NotNull().WithMessage("Name may not be null");

        RuleFor(m => m.Desc)
            .MaximumLength(255).WithMessage("Name length may not be longer than 255")
            .MinimumLength(10).WithMessage("Name length may not be shorter than 10")
            .NotEmpty().WithMessage("Name may not be empty")
            .NotNull().WithMessage("Name may not be null");

        RuleFor(m => m.SalePrice)
            .NotNull().WithMessage("Name may not be null");

        RuleFor(m => m.CostPrice)
            .NotNull().WithMessage("Name may not be null")
            .GreaterThanOrEqualTo(1);

        RuleFor(m => m).Custom((m, context) =>
        {
            if (m.SalePrice < m.CostPrice)
            {
                context.AddFailure(nameof(m.SalePrice), "SalePrice may not be smaller than CostPrice!");
            }
        });
    }

}
