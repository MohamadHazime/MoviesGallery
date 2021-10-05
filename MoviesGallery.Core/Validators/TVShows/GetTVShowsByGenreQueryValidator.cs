using FluentValidation;
using MoviesGallery.Core.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesGallery.Core.Validators.TVShows
{
    class GetTVShowsByGenreQueryValidator : AbstractValidator<GetTVShowsByGenreQuery>
    {
        [Obsolete]
        public GetTVShowsByGenreQueryValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.ApiKey).NotNull().NotEmpty();
            RuleFor(x => x.Query).NotNull().NotEmpty().Equal("discover/tv");
            RuleFor(x => x.Page).NotNull().GreaterThan(0);
            RuleFor(x => x.GenreId).NotNull().GreaterThan(0);
        }
    }
}
