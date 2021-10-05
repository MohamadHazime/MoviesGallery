using MongoDB.Driver;
using MoviesGallery.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoviesGallery.Core.Services
{
    public class MongoMoviesService : IMongoShowsService<MovieDetailsDTO>
    {
        private readonly IMongoCollection<ShowDTO> _movies;
        private readonly IMongoCollection<ShowDetailsDTO> _movieDetails;

        public MongoMoviesService(IMongoService mongo)
        {
            _movies = mongo.GetMoviesCollection();
            _movieDetails = mongo.GetMovieDetailsCollection();
        }

        public async Task<List<ShowDTO>> AddAllAsync(List<ShowDTO> list)
        {
            try
            {
                await _movies.InsertManyAsync(list, options: new InsertManyOptions
                {
                    IsOrdered = false
                });
            }
            catch (MongoBulkWriteException ex)
            {
                Console.WriteLine(ex.ToString());
                return list;
            }

            return list;
        }

        public async Task<MovieDetailsDTO> AddDetailsAsync(MovieDetailsDTO showDetails)
        {
            var movie = await _movieDetails.FindOneAndReplaceAsync(m => m.Id == showDetails.Id, showDetails);

            if(movie == null)
            {
                await _movieDetails.InsertOneAsync(showDetails);
            }

            return showDetails;
        }
    }
}
