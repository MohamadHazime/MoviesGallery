using MediatR;
using MoviesGallery.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesGallery.Core.Commands
{
    public class AddMoviesListCommand : IRequest<List<ShowDTO>>
    {
        public List<ShowDTO> Movies { get; set; }
    }
}
