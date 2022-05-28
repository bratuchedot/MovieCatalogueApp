namespace MovieCatalogueApp.Models
{
    public class MoviePerson
    {
        public Movie Movie { get; set; }
        public List<Person> People { get; set; }
        public int MovieId { get; set; }
        public int PersonId { get; set; }
    }
}
