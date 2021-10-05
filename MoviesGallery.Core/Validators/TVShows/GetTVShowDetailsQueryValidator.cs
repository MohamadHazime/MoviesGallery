using FluentValidation;
using MoviesGallery.Core.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesGallery.Core.Validators
{
    public class GetTVShowDetailsQueryValidator : AbstractValidator<GetTVShowDetailsQuery>
    {
        [Obsolete]
        public GetTVShowDetailsQueryValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.ApiKey).NotNull().NotEmpty();
            RuleFor(x => x.Query).NotNull().NotEmpty().Equal("tv");
            RuleFor(x => x.ShowId).NotNull().GreaterThan(0);
        }
    }
}
