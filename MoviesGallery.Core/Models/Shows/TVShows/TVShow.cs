using System.Collections.Generic;

namespace MoviesGallery.Core.Models
{
    public class TVShow : Show
    {
        public string Name { get; set; }
        public List<string> OriginCountry { get; set; }
        public string FirstAirDate { get; set; }
    }
}
