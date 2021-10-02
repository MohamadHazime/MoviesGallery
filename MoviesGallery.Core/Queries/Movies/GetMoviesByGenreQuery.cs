namespace MoviesGallery.Core.Queries
{
    public class GetMoviesByGenreQuery : GetShowsListQuery
    {
        public int GenreId { get; set; }
    }
}
