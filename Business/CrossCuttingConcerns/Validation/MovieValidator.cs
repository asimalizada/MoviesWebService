using Entities.Concrete;
using FluentValidation;

namespace Business.CrossCuttingConcerns.Validation
{
    public class MovieValidator : AbstractValidator<Movie>
    {
        public MovieValidator()
        {
            RuleFor(m => m.MovieId).NotEmpty();
            RuleFor(m => m.MovieId).GreaterThan(0)
                .WithMessage("Id cannot less than 1");

            RuleFor(m => m.GenreId).NotEmpty();
            RuleFor(m => m.GenreId).GreaterThan(0);

            RuleFor(m => m.Imdb).NotEmpty();
            RuleFor(m => m.Imdb).GreaterThanOrEqualTo(0).LessThanOrEqualTo(10);
            RuleFor(m => m.Imdb).InclusiveBetween(0, 10);

            RuleFor(m => m.MovieName).NotEmpty();
            RuleFor(m => m.MovieName).MinimumLength(2);
            RuleFor(m => m.MovieName).Must(NotStart); // ""
            RuleFor(m => m.MovieName.Trim()).NotEqual("");
            RuleFor(m => m.MovieName.ToLower().Contains("movie"))
                .NotEqual(true);
        }

        private bool NotStart(string movieName)
        {
            return !(movieName.StartsWith("ı")
                     | movieName.StartsWith("ğ")
                     | movieName.StartsWith("I")
                     | movieName.StartsWith("Ğ"));
        }
    }
}