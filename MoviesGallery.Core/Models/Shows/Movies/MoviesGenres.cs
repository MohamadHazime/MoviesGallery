using MoviesGallery.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesGallery.Core.Models
{
    public class MoviesGenres
    {
        private static List<Genre> genres = null;

        public async static Task<List<Genre>> GetGenresList(string apiKey)
        {
            if(genres == null)
            {
                genres = await MoviesService.GetGenres(apiKey);
            }

            return genres;
        }
    }
}