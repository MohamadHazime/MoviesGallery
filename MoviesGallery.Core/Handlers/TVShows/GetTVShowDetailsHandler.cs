using AutoMapper;
using MediatR;
using MoviesGallery.Core.Dtos;
using MoviesGallery.Core.Models;
using MoviesGallery.Core.Queries;
using MoviesGallery.Core.Services;
using System.Threading;
using System.Threading.Tasks;

namespace MoviesGallery.Core.Handlers
{
    public class GetTVShowDetailsHandler : IRequestHandler<GetTVShowDetailsQuery, TVShowDetailsDTO>
    {
        private readonly IShowsService<TVShow, TVShowDetails> _tvShowsService;
        private readonly IMapper _mapper;

        public GetTVShowDetailsHandler(IShowsService<TVShow, TVShowDetails> tvShowsService, IMapper mapper)
        {
            _tvShowsService = tvShowsService;
            _mapper = mapper;
        }

        public async Task<TVShowDetailsDTO> Handle(GetTVShowDetailsQuery request, CancellationToken cancellationToken)
        {
            var queryParams = new QueryParams
            {
                Query = request.Query + "/" + request.ShowId,
            };

            var tvShow = await _tvShowsService.GetByIdAsync(request.ApiKey, queryParams);

            return _mapper.Map<TVShowDetails, TVShowDetailsDTO>(tvShow);
        }
    }
}
