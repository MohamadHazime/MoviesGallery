using MediatR;
using MoviesGallery.Core.Commands;
using MoviesGallery.Core.Dtos;
using MoviesGallery.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MoviesGallery.Core.Handlers
{
    public class AddMoviesListHandler : IRequestHandler<AddMoviesListCommand, List<ShowDTO>>
    {
        private readonly IMongoShowsService<MovieDetailsDTO> _mongoMoviesService;

        public AddMoviesListHandler(IMongoShowsService<MovieDetailsDTO> mongoMoviesService)
        {
            _mongoMoviesService = mongoMoviesService;
        }

        public async Task<List<ShowDTO>> Handle(AddMoviesListCommand request, CancellationToken cancellationToken)
        {
            return await _mongoMoviesService.AddAllAsync(request.Movies);
        }
    }
}
