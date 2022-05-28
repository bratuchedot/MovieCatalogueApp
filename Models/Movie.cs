namespace MovieCatalogueApp.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<Person> CastAndCrew { get; set; }

        public Movie()
        {
            Genres = new List<Genre>();
            CastAndCrew = new List<Person>();
        }
    }
}
