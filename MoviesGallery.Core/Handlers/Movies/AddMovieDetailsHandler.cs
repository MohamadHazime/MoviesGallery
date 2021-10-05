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
    public class AddMovieDetailsHandler : IRequestHandler<AddMovieDetailsCommand, MovieDetailsDTO>
    {
        private readonly IMongoShowsService<MovieDetailsDTO> _mongoMoviesService;

        public AddMovieDetailsHandler(IMongoShowsService<MovieDetailsDTO> mongoMoviesService)
        {
            _mongoMoviesService = mongoMoviesService;
        }

        public async Task<MovieDetailsDTO> Handle(AddMovieDetailsCommand request, CancellationToken cancellationToken)
        {
            return await _mongoMoviesService.AddDetailsAsync(request.ShowDetails);
        }
    }
}
