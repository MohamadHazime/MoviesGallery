using MoviesGallery.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesGallery.Core.Services
{
    public interface IShowsService<T, U>
    {
        Task<List<T>> GetTopRatedAsync(string apiKey, QueryParams queryParams);
        Task<List<T>> GetByGenreAsync(string apiKey, QueryParams queryParams);
        Task<List<T>> GetTopRatedByGenreAsync(string apiKey, QueryParams queryParams);
        Task<U> GetByIdAsync(string apiKey, QueryParams queryParams);
    }
}
