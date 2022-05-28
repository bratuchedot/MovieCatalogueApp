namespace MovieCatalogueApp.Models
{
    public class MovieGenre
    {
        public Movie movie { get; set; }
        public List<Genre> genres { get; set; }
        public int movieId { get; set; }
        public int genreId { get; set; }
    }
}
