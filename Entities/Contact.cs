namespace TechnologySite.Entities
{
    public class Contact
    {
        public int ContactID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime CreateDate { get; set; }
        public string Email { get; set; }
        public string? Image { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public List<Team> Teams { get; set; }


    }
}
