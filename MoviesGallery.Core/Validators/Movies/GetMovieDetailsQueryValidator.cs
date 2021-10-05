using FluentValidation;
using MoviesGallery.Core.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesGallery.Core.Validators
{
    public class GetMovieDetailsQueryValidator : AbstractValidator<GetMovieDetailsQuery>
    {
        [Obsolete]
        public GetMovieDetailsQueryValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.ApiKey).NotNull().NotEmpty();
            RuleFor(x => x.Query).NotNull().NotEmpty().Equal("movie");
            RuleFor(x => x.ShowId).NotNull().GreaterThan(0);
        }
    }
}
