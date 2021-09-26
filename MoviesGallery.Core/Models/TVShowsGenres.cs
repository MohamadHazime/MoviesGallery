using MoviesGallery.Core.Services;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MoviesGallery.Core.Models
{
    public class TVShowsGenres
    {
        private const string _baseUrl = "https://api.themoviedb.org/3/";
        private static List<Genre> genres = null;

        public async static Task<List<Genre>> GetGenresList(string apiKey)
        {
            if(genres == null)
            {
                genres = await TVShowsService.GetGenres(apiKey);
            }

            return genres;
        }
    }
}