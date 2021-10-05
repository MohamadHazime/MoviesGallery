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
    public class GetMovieDetailsHandler : IRequestHandler<GetMovieDetailsQuery, MovieDetailsDTO>
    {
        private readonly IShowsService<Movie, MovieDetails> _moviesService;
        private readonly IMapper _mapper;

        public GetMovieDetailsHandler(IShowsService<Movie, MovieDetails> moviesService, IMapper mapper)
        {
            _moviesService = moviesService;
            _mapper = mapper;
        }

        public async Task<MovieDetailsDTO> Handle(GetMovieDetailsQuery request, CancellationToken cancellationToken)
        {
            var queryParams = new QueryParams
            {
                Query = request.Query + "/" + request.ShowId,
            };

            var movie = await _moviesService.GetByIdAsync(request.ApiKey, queryParams);

            return _mapper.Map<MovieDetails, MovieDetailsDTO>(movie);
        }
    }
}
