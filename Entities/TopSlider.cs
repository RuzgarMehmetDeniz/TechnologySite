namespace TechnologySite.Entities
{
    public class TopSlider
    {
        public int TopSliderID { get; set; }

        // Slider içeriği
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Image { get; set; }

        // Ürün bağlantısı
        public int ProductID { get; set; }
        public Product Product { get; set; }

        // Kontrol
        public bool Status { get; set; }
        public int Order { get; set; }
    }
}
