using System.Collections.Generic;
using TechnologySite.Entities;

public class ProductPriceCompareVM
{
    public List<Product> CheapestProducts { get; set; }
    public List<Product> MostExpensiveProducts { get; set; }
}
