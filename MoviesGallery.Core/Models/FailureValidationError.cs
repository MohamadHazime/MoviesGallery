using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesGallery.Core.Models
{
    public class FailureValidationError
    {
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
    }
}
