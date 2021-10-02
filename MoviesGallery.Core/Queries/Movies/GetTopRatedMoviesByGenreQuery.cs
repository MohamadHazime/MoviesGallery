namespace MoviesGallery.Core.Queries
{
    public class GetTopRatedMoviesByGenreQuery : GetShowsListQuery
    {
        public int GenreId { get; set; }
    }
}
