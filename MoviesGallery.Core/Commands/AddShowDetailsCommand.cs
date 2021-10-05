using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesGallery.Core.Commands
{
    public abstract class AddShowDetailsCommand<T> : IRequest<T>
    {
        public T ShowDetails { get; set; }
    }
}
