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
    public class TVShowsController : ControllerBase
    {
        private readonly IShowsService<TVShow, TVShowDetails> _tvShowsService;
        private readonly IMapper _mapper;

        public TVShowsController(IShowsService<TVShow, TVShowDetails> tvShowsService, IMapper mapper)
        {
            _tvShowsService = tvShowsService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get(
            [FromHeader(Name = "api-key")] string api_key, 
            [FromQuery(Name = "tv-shows-query")] string tv_shows_query, 
            [FromQuery(Name = "page")] int page)
        {
            var queryParams = new QueryParams 
            {   
                Query = tv_shows_query,
                Page = page
            };

            var tvShowsList = await _tvShowsService.GetAllAsync(api_key, queryParams);

            var tvShowsListDTO = _mapper.Map<List<TVShow>, List<ShowDTO>>(tvShowsList);

            return Ok(tvShowsListDTO);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(
            [FromHeader(Name = "api-key")] string api_key, 
            [FromQuery(Name = "tv-shows-query")] string tv_shows_query,
            int id)
        {
            var queryParams = new QueryParams 
            {   
                Query = tv_shows_query + "/" + id,
            };

            var tvShow = await _tvShowsService.GetByIdAsync(api_key, queryParams);

            var tvShowDTO = _mapper.Map<TVShowDetails, TVShowDetailsDTO>(tvShow);

            return Ok(tvShowDTO);
        }

        [HttpGet]
        [Route("top-rated")]
        public async Task<IActionResult> GetTopRated(
            [FromHeader(Name = "api-key")] string api_key, 
            [FromQuery(Name = "tv-shows-query")] string tv_shows_query)
        {
            var queryParams = new QueryParams 
            {   
                Query = tv_shows_query,
                Page = 1
            };

            var tvShowsList = await _tvShowsService.GetTopRatedAsync(api_key, queryParams);

            var tvShowsListDTO = _mapper.Map<List<TVShow>, List<ShowDTO>>(tvShowsList);

            return Ok(tvShowsListDTO);
        }

        [HttpGet]
        [Route("genre/{id}")]
        public async Task<IActionResult> GetByGenre(
            [FromHeader(Name = "api-key")] string api_key, 
            [FromQuery(Name = "tv-shows-query")] string tv_shows_query,
            [FromQuery(Name = "page")] int page,
            int id)
        {
            var queryParams = new QueryParams 
            {   
                Query = tv_shows_query,
                Page = page,
                GenreId = id
            };

            var tvShowsList = await _tvShowsService.GetByGenreAsync(api_key, queryParams);

            var tvShowsListDTO = _mapper.Map<List<TVShow>, List<ShowDTO>>(tvShowsList);

            return Ok(tvShowsListDTO);
        }

        [HttpGet]
        [Route("genre/{id}/top-rated")]
        public async Task<IActionResult> GetTopRatedByGenre(
            [FromHeader(Name = "api-key")] string api_key, 
            [FromQuery(Name = "tv-shows-query")] string tv_shows_query,
            int id)
        {
            var queryParams = new QueryParams() 
            {
                Query = tv_shows_query,
                GenreId = id,
                Page = 1
            };

            var tvShowsList = await _tvShowsService.GetTopRatedByGenreAsync(api_key, queryParams);

            var tvShowsListDTO = _mapper.Map<List<TVShow>, List<ShowDTO>>(tvShowsList);

            return Ok(tvShowsListDTO);
        }
    }
}