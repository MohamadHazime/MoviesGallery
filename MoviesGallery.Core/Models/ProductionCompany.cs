using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesGallery.Core.Models
{
    public class ProductionCompany
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OriginCountry { get; set; }
        public string LogoPath { get; set; }
    }
}