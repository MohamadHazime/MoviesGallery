using AutoMapper;
using FluentValidation;
using MediatR;
using MoviesGallery.Core.Dtos;
using MoviesGallery.Core.Models;
using MoviesGallery.Core.Queries;
using MoviesGallery.Core.Services;
using MoviesGallery.Core.Validators;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MoviesGallery.Core.Handlers
{
    public class GetTopRatedMoviesHandler : IRequestHandler<GetTopRatedMoviesQuery, List<ShowDTO>>
    {
        private readonly IShowsService<Movie, MovieDetails> _moviesService;
        private readonly IMapper _mapper;

        public GetTopRatedMoviesHandler(IShowsService<Movie, MovieDetails> moviesService, IMapper mapper) 
        {
            _moviesService = moviesService;
            _mapper = mapper;
        }

        public async Task<List<ShowDTO>> Handle(GetTopRatedMoviesQuery request, CancellationToken cancellationToken)
        {
            var queryParams = new QueryParams
            {
                Query = request.Query,
                Page = request.Page
            };

            var moviesList = await _moviesService.GetTopRatedAsync(request.ApiKey, queryParams);

            return _mapper.Map<List<Movie>, List<ShowDTO>>(moviesList);
        }
    }
}
