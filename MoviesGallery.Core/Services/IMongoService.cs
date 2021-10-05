using MongoDB.Driver;
using MoviesGallery.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesGallery.Core.Services
{
    public interface IMongoService
    {
        IMongoCollection<ShowDTO> GetMoviesCollection();
        IMongoCollection<ShowDTO> GetTVShowsCollection();
        IMongoCollection<ShowDetailsDTO> GetMovieDetailsCollection();
        IMongoCollection<ShowDetailsDTO> GetTVShowDetailsCollection();
    }
}
