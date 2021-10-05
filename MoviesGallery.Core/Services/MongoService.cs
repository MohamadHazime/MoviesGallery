using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MoviesGallery.Core.Configurations;
using MoviesGallery.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesGallery.Core.Services
{
    public class MongoService : IMongoService
    {
        private readonly IMongoDatabase _database;
        private readonly IOptions<MoviesDbConfig> _moviesDbCongig;

        public MongoService(IOptions<MoviesDbConfig> moviesDbCongig)
        {
            var client = new MongoClient(moviesDbCongig.Value.Connection_String);
            _database = client.GetDatabase(moviesDbCongig.Value.Database_Name);
            _moviesDbCongig = moviesDbCongig;
        }

        public IMongoCollection<ShowDetailsDTO> GetMovieDetailsCollection()
        {
            return _database.GetCollection<ShowDetailsDTO>(_moviesDbCongig.Value.Movie_Details_Collection);
        }

        public IMongoCollection<ShowDTO> GetMoviesCollection() 
        {
            return _database.GetCollection<ShowDTO>(_moviesDbCongig.Value.Movies_Collection);
        }

        public IMongoCollection<ShowDetailsDTO> GetTVShowDetailsCollection()
        {
            return _database.GetCollection<ShowDetailsDTO>(_moviesDbCongig.Value.TVShow_Details_Collection);
        }

        public IMongoCollection<ShowDTO> GetTVShowsCollection()
        {
            return _database.GetCollection<ShowDTO>(_moviesDbCongig.Value.TVShows_Collection);
        }
    }
}
