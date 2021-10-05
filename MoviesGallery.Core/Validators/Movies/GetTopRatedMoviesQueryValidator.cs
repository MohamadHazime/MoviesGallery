using FluentValidation;
using MoviesGallery.Core.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesGallery.Core.Validators
{
    public class GetTopRatedMoviesQueryValidator : AbstractValidator<GetTopRatedMoviesQuery>
    {
        [Obsolete]
        public GetTopRatedMoviesQueryValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.ApiKey).NotNull().NotEmpty();
            RuleFor(x => x.Query).NotNull().NotEmpty().Equal("movie/top_rated");
            RuleFor(x => x.Page).NotNull().NotEmpty().Equal(1);
        }
    }
}
