﻿namespace MoviesGallery.Core.Models
{
    public abstract class QueryRequest
    {
        public string ApiKey { get; set; }
        public string Query { get; set; }
    }
}
