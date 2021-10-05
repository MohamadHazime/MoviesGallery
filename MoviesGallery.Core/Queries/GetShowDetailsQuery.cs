using MediatR;
using MoviesGallery.Core.Dtos;
using MoviesGallery.Core.Models;

namespace MoviesGallery.Core.Queries
{
    public abstract class GetShowDetailsQuery<T> : QueryRequest, IRequest<T>
    {
        public int ShowId { get; set; }
    }
}
