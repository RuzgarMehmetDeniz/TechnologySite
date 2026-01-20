using TechnologySite.Entities;
using System.Collections.Generic;

namespace TechnologySite.ViewModels
{
    public class ShopViewModel
    {
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
        public int? SelectedCategoryId { get; set; }
    }
}
