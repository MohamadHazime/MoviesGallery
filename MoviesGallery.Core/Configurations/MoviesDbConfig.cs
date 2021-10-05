using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesGallery.Core.Configurations
{
    public class MoviesDbConfig
    {
        public string Database_Name { get; set; }
        public string Connection_String { get; set; }
        public string Movies_Collection { get; set; }
        public string TVShows_Collection { get; set; }
        public string Movie_Details_Collection { get; set; }
        public string TVShow_Details_Collection { get; set; }
    }
}
