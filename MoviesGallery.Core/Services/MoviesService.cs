using MoviesGallery.Core.Models;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesGallery.Core.Services
{
    public class MoviesService : IShowsService<Movie, MovieDetails>
    {
        private static readonly RestClient _client = MyRestClient.GetRestClientObject();

        private List<string> moviesTest = new List<string>
        {
            "Movie 1",
        };

        public async Task<List<Movie>> GetByGenreAsync(string apiKey, QueryParams queryParams)
        {
            var request = new RestRequest(queryParams.Query)
                .AddParameter("api_key", apiKey)
                .AddParameter("sort_by", "popularity.desc")
                .AddParameter("with_genres", queryParams.GenreId)
                .AddParameter("page", queryParams.Page);
            var response = await _client.GetAsync<MoviesResponse>(request);

            var movies = response.Results;

            var genresList = await MoviesGenres.GetGenresList(apiKey);

            foreach(var movie in movies)
            {
                movie.Genres = new List<string>();
                foreach(var genreId in movie.GenreIds)
                {
                    var genre = genresList.Find((gnr) => gnr.Id == genreId);
                    if(genre != null) 
                    {
                        movie.Genres.Add(genre.Name);            
                    }           
                }
            }

            return movies;
        }

        public async Task<MovieDetails> GetByIdAsync(string apiKey, QueryParams queryParams)
        {
            var request = new RestRequest(queryParams.Query)
                .AddParameter("api_key", apiKey);
            var response = await _client.GetAsync<MovieDetails>(request);

            return response;
        }

        public async Task<List<Movie>> GetTopRatedAsync(string apiKey, QueryParams queryParams)
        {
            var request = new RestRequest(queryParams.Query)
                .AddParameter("api_key", apiKey)
                .AddParameter("page", queryParams.Page);
            var response = await _client.GetAsync<MoviesResponse>(request);

            var movies = response.Results.GetRange(0, 6);

            var genresList = await MoviesGenres.GetGenresList(apiKey);

            foreach(var movie in movies)
            {
                movie.Genres = new List<string>();
                foreach(var genreId in movie.GenreIds)
                {
                    var genre = genresList.Find((gnr) => gnr.Id == genreId);
                    if(genre != null) 
                    {
                        movie.Genres.Add(genre.Name);            
                    }           
                }
            }

            return movies;
        }

        public async Task<List<Movie>> GetTopRatedByGenreAsync(string apiKey, QueryParams queryParams)
        {
            var movies = new List<Movie>();
            int page = queryParams.Page;
            
            while(movies.Count < 3)
            {
                var request = new RestRequest(queryParams.Query)
                    .AddParameter("api_key", apiKey)
                    .AddParameter("page", page);
                var response = await _client.GetAsync<MoviesResponse>(request);

                movies.AddRange(response.Results.FindAll((movie) => movie.GenreIds.Contains(queryParams.GenreId)));

                page++;
            }

            movies = movies.GetRange(0, 3);

            var genresList = await MoviesGenres.GetGenresList(apiKey);

            foreach(var movie in movies)
            {
                movie.Genres = new List<string>();
                foreach(var genreId in movie.GenreIds)
                {
                    var genre = genresList.Find((gnr) => gnr.Id == genreId);
                    if(genre != null) 
                    {
                        movie.Genres.Add(genre.Name);            
                    }             
                }
            }

            return movies;
        }
        
        public static async Task<List<Genre>> GetGenres(string apiKey)
        {
            var request = new RestRequest("genre/movie/list")
                .AddParameter("api_key", apiKey);
            var response = await _client.GetAsync<GenresResponse>(request);

            return response.Genres;
        }
    }
}
