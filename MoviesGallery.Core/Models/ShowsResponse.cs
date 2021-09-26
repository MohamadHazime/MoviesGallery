using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesGallery.Core.Models
{
    public abstract class ShowsResponse<T>
    {
        public List<T> Results { get; set; }
        public int Page { get; set; }
        public int TotalPages { get; set; }
        public int TotalResults { get; set; }
    }
}
