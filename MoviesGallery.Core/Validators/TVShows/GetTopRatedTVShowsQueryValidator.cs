﻿using FluentValidation;
using MoviesGallery.Core.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesGallery.Core.Validators
{
    public class GetTopRatedTVShowsQueryValidator : AbstractValidator<GetTopRatedTVShowsQuery>
    {
        [Obsolete]
        public GetTopRatedTVShowsQueryValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.ApiKey).NotNull().NotEmpty();
            RuleFor(x => x.Query).NotNull().NotEmpty().Equal("tv/top_rated");
            RuleFor(x => x.Page).NotNull().NotEmpty().Equal(1);
        }
    }
}
