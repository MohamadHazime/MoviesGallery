namespace MoviesGallery.Core.Queries
{
    public class GetTVShowsByGenreQuery : GetShowsListQuery
    {
        public int GenreId { get; set; }
    }
}
