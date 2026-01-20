namespace TechnologySite.Entities
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public string? Image { get; set; }
        public List<Product> Products { get; set; }
        public List<Footer> Footers { get; set; }
    }
}
