using TechnologySite.Entities;

namespace TechnologySite.Models
{
    public class IndexViewModel
    {
        public List<Product> Products { get; set; }
        public List<Footer> Footers { get; set; }
        public List<Category> Categories { get; set; }
        public List<TopSlider> TopSliders { get; set; }  // Üst slider ürünleri
    }

}
