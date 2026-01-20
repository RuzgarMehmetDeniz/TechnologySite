namespace TechnologySite.Entities
{
    public class Team
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string InstagramUrl { get; set; }
        public string XUrl { get; set; }
        public string LınkedInUrl { get; set; }
        public int? AboutID { get; set; }
        public About About { get; set; }
        public int? ContactID { get; set; }
        public Contact Contact { get; set; }
    }
}
