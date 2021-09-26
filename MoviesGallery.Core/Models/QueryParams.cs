using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesGallery.Core.Models
{
    public class QueryParams
    {
        public string Query { get; set; }
        public int Page { get; set; }
        public int GenreId { get; set; }
    }
}