namespace TechnologySite.Entities
{
    public class About
    {
        public int AboutID { get; set; }
        public string AboutName { get; set; }
        public string Description { get; set; }
        public string AboutDescription { get; set; }
        public string AboutImage { get; set; }
        public DateTime DateTime { get; set; }
        public List<Team> Teams { get; set; }

    }
}
