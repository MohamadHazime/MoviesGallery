using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesGallery.Core.Models
{
    public class Movie : Show
    {
        public string Title { get; set; }
        public string ReleaseDate { get; set; }
    }
}
