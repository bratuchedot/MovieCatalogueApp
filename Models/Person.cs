namespace MovieCatalogueApp.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }

        public Person()
        {
            Roles = new List<Role>();
            Movies = new List<Movie>();
        }
    }
}
