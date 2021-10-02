using MediatR;
using MoviesGallery.Core.Dtos;
using MoviesGallery.Core.Models;

namespace MoviesGallery.Core.Queries
{
    public abstract class GetShowDetailsQuery : QueryRequest, IRequest<ShowDetailsDTO>
    {
        public int ShowId { get; set; }
    }
}
