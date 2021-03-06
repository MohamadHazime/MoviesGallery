using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoviesGallery.Core.Commands;
using MoviesGallery.Core.Queries;

namespace MoviesGallery.API.Controllers 
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MoviesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(
            [FromHeader(Name = "api-key")] string api_key, 
            [FromQuery(Name = "movies-query")] string movies_query,  
            int id)
        {
            var query = new GetMovieDetailsQuery
            {
                ApiKey = api_key,
                Query = movies_query,
                ShowId = id,
            };

            var result = await _mediator.Send(query);

            // var command = new AddMovieDetailsCommand
            // {
            //     ShowDetails = result
            // };

            // await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        [Route("top-rated")]
        public async Task<IActionResult> GetTopRated(
            [FromHeader(Name = "api-key")] string api_key, 
            [FromQuery(Name = "movies-query")] string movies_query)
        {
            var query = new GetTopRatedMoviesQuery
            {
                ApiKey = api_key,
                Query = movies_query,
                Page = 1
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        [Route("genre/{id}")]
        public async Task<IActionResult> GetByGenre(
            [FromHeader(Name = "api-key")] string api_key, 
            [FromQuery(Name = "movies-query")] string movies_query,
            [FromQuery(Name = "page")] int page,
            int id)
        {
            var query = new GetMoviesByGenreQuery
            {
                ApiKey = api_key,
                Query = movies_query,
                Page = page,
                GenreId = id,
            };

            var result = await _mediator.Send(query);

            var command = new AddMoviesListCommand
            {
                Movies = result
            };

            await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        [Route("genre/{id}/top-rated")]
        public async Task<IActionResult> GetTopRatedByGenre(
            [FromHeader(Name = "api-key")] string api_key, 
            [FromQuery(Name = "movies-query")] string movies_query,
            int id)
        {
            var query = new GetTopRatedMoviesByGenreQuery
            {
                ApiKey = api_key,
                Query = movies_query,
                Page = 1,
                GenreId = id,
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}