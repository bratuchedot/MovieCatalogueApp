namespace MovieCatalogueApp.Models
{
    public class PersonRole
    {
        public Person Person { get; set; }
        public List<Role> Roles { get; set; }
        public int PersonId { get; set; }
        public int RoleId { get; set; }
    }
}
