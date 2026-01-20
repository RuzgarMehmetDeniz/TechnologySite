namespace TechnologySite.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public bool Status { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public DateTime DateTime { get; set; }
        public List<CartItem> CartItems { get; set; }
        public Slider Slider { get; set; }
        public ICollection<TopSlider> TopSliders { get; set; }
        public ICollection<Sales> Sales { get; set; } = new List<Sales>();



    }
}
