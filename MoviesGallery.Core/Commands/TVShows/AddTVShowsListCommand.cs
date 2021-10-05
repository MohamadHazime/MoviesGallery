using MediatR;
using MoviesGallery.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesGallery.Core.Commands
{
    public class AddTVShowsListCommand : IRequest<List<ShowDTO>>
    {
        public List<ShowDTO> TvShows { get; set; }
    }
}
