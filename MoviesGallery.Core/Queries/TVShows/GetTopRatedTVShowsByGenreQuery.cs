namespace MoviesGallery.Core.Queries
{
    public class GetTopRatedTVShowsByGenreQuery : GetShowsListQuery
    {
        public int GenreId { get; set; }
    }
}
