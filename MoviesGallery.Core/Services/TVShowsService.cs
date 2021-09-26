using MoviesGallery.Core.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoviesGallery.Core.Services
{
    public class TVShowsService : IShowsService<TVShow, TVShowDetails>
    {
        private static readonly RestClient _client = MyRestClient.GetRestClientObject();

        public TVShowsService()
        {
            // _client = MyRestClient.GetRestClientObject();
        }

        public async Task<List<TVShow>> GetAllAsync(string apiKey, QueryParams queryParams)
        {
            var request = new RestRequest(queryParams.Query)
                .AddParameter("api_key", apiKey)
                .AddParameter("page", queryParams.Page);
            var response = await _client.GetAsync<TVShowsResponse>(request);

            var tvShows = response.Results;

            var genresList = await TVShowsGenres.GetGenresList(apiKey);

            foreach(var tvShow in tvShows)
            {
                tvShow.Genres = new List<string>();
                foreach(var genreId in tvShow.GenreIds)
                {
                    var genre = genresList.Find((gnr) => gnr.Id == genreId);
                    tvShow.Genres.Add(genre.Name);            
                }
            }

            return tvShows;
        }

        public async Task<List<TVShow>> GetByGenreAsync(string apiKey, QueryParams queryParams)
        {
            var request = new RestRequest(queryParams.Query)
                .AddParameter("api_key", apiKey)
                .AddParameter("sort_by", "popularity.desc")
                .AddParameter("with_genres", queryParams.GenreId)
                .AddParameter("page", queryParams.Page);
            var response = await _client.GetAsync<TVShowsResponse>(request);

            var tvShows = response.Results;

            var genresList = await TVShowsGenres.GetGenresList(apiKey);

            foreach(var tvShow in tvShows)
            {
                tvShow.Genres = new List<string>();
                foreach(var genreId in tvShow.GenreIds)
                {
                    var genre = genresList.Find((gnr) => gnr.Id == genreId);
                    if(genre != null) 
                    {
                        tvShow.Genres.Add(genre.Name);            
                    }
                }
            }

            return tvShows;
        }

        public async Task<TVShowDetails> GetByIdAsync(string apiKey, QueryParams queryParams)
        {
            var request = new RestRequest(queryParams.Query)
                .AddParameter("api_key", apiKey);
            var response = await _client.GetAsync<TVShowDetails>(request);

            return response;
        }

        public async Task<List<TVShow>> GetTopRatedAsync(string apiKey, QueryParams queryParams)
        {
            var request = new RestRequest(queryParams.Query)
                .AddParameter("api_key", apiKey)
                .AddParameter("page", queryParams.Page);
            var response = await _client.GetAsync<TVShowsResponse>(request);

            var tvShows = response.Results.GetRange(0, 6);

            var genresList = await TVShowsGenres.GetGenresList(apiKey);

            foreach(var tvShow in tvShows)
            {
                tvShow.Genres = new List<string>();
                foreach(var genreId in tvShow.GenreIds)
                {
                    var genre = genresList.Find((gnr) => gnr.Id == genreId);
                    if(genre != null) 
                    {
                        tvShow.Genres.Add(genre.Name);            
                    }           
                }
            }

            return tvShows;
        }

        public async Task<List<TVShow>> GetTopRatedByGenreAsync(string apiKey, QueryParams queryParams)
        {
            var tvShows = new List<TVShow>();
            int page = queryParams.Page;
            
            while(tvShows.Count < 3)
            {
                var request = new RestRequest(queryParams.Query)
                    .AddParameter("api_key", apiKey)
                    .AddParameter("page", page);
                var response = await _client.GetAsync<TVShowsResponse>(request);

                tvShows.AddRange(response.Results.FindAll((movie) => movie.GenreIds.Contains(queryParams.GenreId)));

                page++;
            }

            tvShows = tvShows.GetRange(0, 3);

            var genresList = await TVShowsGenres.GetGenresList(apiKey);

            foreach(var tvShow in tvShows)
            {
                tvShow.Genres = new List<string>();
                foreach(var genreId in tvShow.GenreIds)
                {
                    var genre = genresList.Find((gnr) => gnr.Id == genreId);
                    if(genre != null) 
                    {
                        tvShow.Genres.Add(genre.Name);            
                    }           
                }
            }

            return tvShows;
        }

        public static async Task<List<Genre>> GetGenres(string apiKey)
        {
            var request = new RestRequest("genre/tv/list")
                .AddParameter("api_key", apiKey);
            var response = await _client.GetAsync<GenresResponse>(request);

            return response.Genres;
        }
    }
}
