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
    public class AddTVShowsListHandler : IRequestHandler<AddTVShowsListCommand, List<ShowDTO>>
    {
        private readonly IMongoShowsService<TVShowDetailsDTO> _mongoTVShowsService;

        public AddTVShowsListHandler(IMongoShowsService<TVShowDetailsDTO> mongoTVShowsService)
        {
            _mongoTVShowsService = mongoTVShowsService;
        }

        public async Task<List<ShowDTO>> Handle(AddTVShowsListCommand request, CancellationToken cancellationToken)
        {
            return await _mongoTVShowsService.AddAllAsync(request.TvShows);
        }
    }
}
