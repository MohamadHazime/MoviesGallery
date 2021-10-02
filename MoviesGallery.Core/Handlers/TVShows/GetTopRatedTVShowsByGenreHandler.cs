using AutoMapper;
using MediatR;
using MoviesGallery.Core.Dtos;
using MoviesGallery.Core.Models;
using MoviesGallery.Core.Queries;
using MoviesGallery.Core.Services;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MoviesGallery.Core.Handlers
{
    public class GetTopRatedTVShowsByGenreHandler : IRequestHandler<GetTopRatedTVShowsByGenreQuery, List<ShowDTO>>
    {
        private readonly IShowsService<TVShow, TVShowDetails> _tvShowsService;
        private readonly IMapper _mapper;

        public GetTopRatedTVShowsByGenreHandler(IShowsService<TVShow, TVShowDetails> tvShowsService, IMapper mapper)
        {
            _tvShowsService = tvShowsService;
            _mapper = mapper;
        }

        public async Task<List<ShowDTO>> Handle(GetTopRatedTVShowsByGenreQuery request, CancellationToken cancellationToken)
        {
            var queryParams = new QueryParams
            {
                Query = request.Query,
                Page = request.Page,
                GenreId = request.GenreId
            };

            var tvShowsList = await _tvShowsService.GetTopRatedByGenreAsync(request.ApiKey, queryParams);

            return _mapper.Map<List<TVShow>, List<ShowDTO>>(tvShowsList);
        }
    }
}
