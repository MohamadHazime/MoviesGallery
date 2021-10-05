using MediatR;
using MoviesGallery.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesGallery.Core.Commands
{
    public class AddMovieDetailsCommand : AddShowDetailsCommand<MovieDetailsDTO>
    {
    }
}
