using FluentValidation;
using MoviesGallery.Core.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesGallery.Core.Validators
{
    public class GetTopRatedMoviesByGenreQueryValidator : AbstractValidator<GetTopRatedMoviesByGenreQuery>
    {
        [Obsolete]
        public GetTopRatedMoviesByGenreQueryValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.ApiKey).NotNull().NotEmpty();
            RuleFor(x => x.Query).NotNull().NotEmpty().Equal("movie/top_rated");
            RuleFor(x => x.Page).NotNull().Equal(1);
            RuleFor(x => x.GenreId).NotNull().GreaterThan(0);
        }
    }
}
