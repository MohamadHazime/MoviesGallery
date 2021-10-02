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
    public class GetTopRatedMoviesByGenreHandler : IRequestHandler<GetTopRatedMoviesByGenreQuery, List<ShowDTO>>
    {
        private readonly IShowsService<Movie, MovieDetails> _moviesService;
        private readonly IMapper _mapper;

        public GetTopRatedMoviesByGenreHandler(IShowsService<Movie, MovieDetails> moviesService, IMapper mapper)
        {
            _moviesService = moviesService;
            _mapper = mapper;
        }

        public async Task<List<ShowDTO>> Handle(GetTopRatedMoviesByGenreQuery request, CancellationToken cancellationToken)
        {
            var queryParams = new QueryParams
            {
                Query = request.Query,
                Page = request.Page,
                GenreId = request.GenreId
            };

            var moviesList = await _moviesService.GetTopRatedByGenreAsync(request.ApiKey, queryParams);

            return _mapper.Map<List<Movie>, List<ShowDTO>>(moviesList);
        }
    }
}
