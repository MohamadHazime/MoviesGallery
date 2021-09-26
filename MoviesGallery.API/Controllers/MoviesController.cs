using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesGallery.Core.Dtos;
using MoviesGallery.Core.Models;
using MoviesGallery.Core.Services;

namespace MoviesGallery.API.Controllers 
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IShowsService<Movie, MovieDetails> _moviesService;
        private readonly IMapper _mapper;

        public MoviesController(IShowsService<Movie, MovieDetails> moviesService, IMapper mapper)
        {
            _moviesService = moviesService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get(
            [FromHeader(Name = "api-key")] string api_key, 
            [FromQuery(Name = "movies-query")] string movies_query, 
            [FromQuery(Name = "page")] int page)
        {
            var queryParams = new QueryParams 
            {   
                Query = movies_query,
                Page = page
            };

            var moviesList = await _moviesService.GetAllAsync(api_key, queryParams);

            var moviesListDTO = _mapper.Map<List<Movie>, List<ShowDTO>>(moviesList);

            return Ok(moviesListDTO);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(
            [FromHeader(Name = "api-key")] string api_key, 
            [FromQuery(Name = "movies-query")] string movies_query,  
            int id)
        {
            var queryParams = new QueryParams 
            {   
                Query = movies_query + "/" + id,
            };

            var movie = await _moviesService.GetByIdAsync(api_key, queryParams);

            var movieDTO = _mapper.Map<MovieDetails, MovieDetailsDTO>(movie);

            return Ok(movieDTO);
        }

        [HttpGet]
        [Route("top-rated")]
        public async Task<IActionResult> GetTopRated(
            [FromHeader(Name = "api-key")] string api_key, 
            [FromQuery(Name = "movies-query")] string movies_query)
        {
            var queryParams = new QueryParams 
            {   
                Query = movies_query,
                Page = 1
            };

            var moviesList = await _moviesService.GetTopRatedAsync(api_key, queryParams);

            var moviesListDTO = _mapper.Map<List<Movie>, List<ShowDTO>>(moviesList);

            return Ok(moviesListDTO);
        }

        [HttpGet]
        [Route("genre/{id}")]
        public async Task<IActionResult> GetByGenre(
            [FromHeader(Name = "api-key")] string api_key, 
            [FromQuery(Name = "movies-query")] string movies_query,
            [FromQuery(Name = "page")] int page,
            int id)
        {
            var queryParams = new QueryParams 
            {   
                Query = movies_query,
                Page = page,
                GenreId = id
            };

            var moviesList = await _moviesService.GetByGenreAsync(api_key, queryParams);

            var moviesListDTO = _mapper.Map<List<Movie>, List<ShowDTO>>(moviesList);

            return Ok(moviesListDTO);
        }

        [HttpGet]
        [Route("genre/{id}/top-rated")]
        public async Task<IActionResult> GetTopRatedByGenre(
            [FromHeader(Name = "api-key")] string api_key, 
            [FromQuery(Name = "movies-query")] string movies_query,
            int id)
        {
            var queryParams = new QueryParams() 
            {
                Query = movies_query,
                GenreId = id,
                Page = 1
            };

            var moviesList = await _moviesService.GetTopRatedByGenreAsync(api_key, queryParams);

            var moviesListDTO = _mapper.Map<List<Movie>, List<ShowDTO>>(moviesList);

            return Ok(moviesListDTO);
        }
    }
}