using MoviesGallery.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoviesGallery.Core.Services
{
    public interface IMongoShowsService<T>
    {
        Task<List<ShowDTO>> AddAllAsync(List<ShowDTO> list);
        Task<T> AddDetailsAsync(T showDetails);
    }
}
