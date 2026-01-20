using System.ComponentModel.DataAnnotations.Schema;

namespace TechnologySite.Entities
{
    public class Sales
    {
        public int Id { get; set; }

        public DateTime SaleDate { get; set; }

        public decimal Amount { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }
}
