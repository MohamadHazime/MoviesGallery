using MoviesGallery.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoviesGallery.Core.Services
{
    public interface IShowsService<T, U>
    {
        Task<List<T>> GetAllAsync(string apiKey, QueryParams queryParams);
        Task<List<T>> GetTopRatedAsync(string apiKey, QueryParams queryParams);
        Task<List<T>> GetByGenreAsync(string apiKey, QueryParams queryParams);
        Task<List<T>> GetTopRatedByGenreAsync(string apiKey, QueryParams queryParams);
        Task<U> GetByIdAsync(string apiKey, QueryParams queryParams);
    }
}
