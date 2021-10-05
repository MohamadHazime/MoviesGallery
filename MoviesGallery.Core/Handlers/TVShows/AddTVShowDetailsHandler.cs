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
    public class AddTVShowDetailsHandler : IRequestHandler<AddTVShowDetailsCommand, TVShowDetailsDTO>
    {
        private readonly IMongoShowsService<TVShowDetailsDTO> _mongoTVShowService;

        public AddTVShowDetailsHandler(IMongoShowsService<TVShowDetailsDTO> mongoTVShowService)
        {
            _mongoTVShowService = mongoTVShowService;
        }

        public async Task<TVShowDetailsDTO> Handle(AddTVShowDetailsCommand request, CancellationToken cancellationToken)
        {
            return await _mongoTVShowService.AddDetailsAsync(request.ShowDetails);
        }
    }
}
