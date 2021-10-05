using FluentValidation;
using MoviesGallery.Core.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesGallery.Core.Validators
{
    public class GetTopRatedTVShowsByGenreQueryValidator : AbstractValidator<GetTopRatedTVShowsByGenreQuery>
    {
        [Obsolete]
        public GetTopRatedTVShowsByGenreQueryValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.ApiKey).NotNull().NotEmpty();
            RuleFor(x => x.Query).NotNull().NotEmpty().Equal("tv/top_rated");
            RuleFor(x => x.Page).NotNull().Equal(1);
            RuleFor(x => x.GenreId).NotNull().GreaterThan(0);
        }
    }
}
