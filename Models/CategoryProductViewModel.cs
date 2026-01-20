using System.Collections.Generic;
using TechnologySite.Entities;
using TechnologySite.ViewModels;

namespace TechnologySite.Models
{
    public class CategoryProductViewModel
    {
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
        public int CategoryID { get; set; }
        public int? SelectedCategoryId { get; set; }
    }
}
