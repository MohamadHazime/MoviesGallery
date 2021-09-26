using System;
using System.Collections.Generic;
using System.Text;
using MoviesGallery.Core.Models;

namespace MoviesGallery.Core.Dtos
{
    public class TVShowDetailsDTO : ShowDetailsDTO
    {
        public List<Season> Seasons { get; set; }
    }
}