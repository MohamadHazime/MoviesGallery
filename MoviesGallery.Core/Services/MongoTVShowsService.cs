using MongoDB.Driver;
using MoviesGallery.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoviesGallery.Core.Services
{
    public class MongoTVShowsService : IMongoShowsService<TVShowDetailsDTO>
    {
        private readonly IMongoCollection<ShowDTO> _tvShows;
        private readonly IMongoCollection<ShowDetailsDTO> _tvShowDetails;

        public MongoTVShowsService(IMongoService mongo)
        {
            _tvShows = mongo.GetTVShowsCollection();
            _tvShowDetails = mongo.GetTVShowDetailsCollection();
        }

        public async Task<List<ShowDTO>> AddAllAsync(List<ShowDTO> list)
        {
            try
            {
                await _tvShows.InsertManyAsync(list, options: new InsertManyOptions
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

        public async Task<TVShowDetailsDTO> AddDetailsAsync(TVShowDetailsDTO showDetails)
        {
            var movie = await _tvShowDetails.FindOneAndReplaceAsync(t => t.Id == showDetails.Id, showDetails);

            if (movie == null)
            {
                await _tvShowDetails.InsertOneAsync(showDetails);
            }

            return showDetails;
        }
    }
}
