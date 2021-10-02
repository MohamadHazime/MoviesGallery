using MediatR;
using MoviesGallery.Core.Dtos;
using MoviesGallery.Core.Models;
using System.Collections.Generic;

namespace MoviesGallery.Core.Queries
{
    public abstract class GetShowsListQuery : QueryRequest, IRequest<List<ShowDTO>>
    {
        public int Page { get; set; }
    }
}
