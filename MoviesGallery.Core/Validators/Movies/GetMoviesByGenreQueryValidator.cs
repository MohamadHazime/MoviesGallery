using FluentValidation;
using MoviesGallery.Core.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesGallery.Core.Validators
{
    public class GetMoviesByGenreQueryValidator : AbstractValidator<GetMoviesByGenreQuery>
    {
        [Obsolete]
        public GetMoviesByGenreQueryValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.ApiKey).NotNull().NotEmpty();
            RuleFor(x => x.Query).NotNull().NotEmpty().Equal("discover/movie");
            RuleFor(x => x.Page).NotNull().GreaterThan(0);
            RuleFor(x => x.GenreId).NotNull().GreaterThan(0);
        }
    }
}
