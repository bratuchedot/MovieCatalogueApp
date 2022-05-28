namespace MovieCatalogueApp.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Person> People { get; set; }

        public Role()
        {
            People = new List<Person>();
        }
    }
}
