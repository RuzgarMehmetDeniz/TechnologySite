namespace TechnologySite.Entities
{
    public class Cart
    {
        public int CartId { get; set; }
        public string UserID { get; set; } 
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public ICollection<CartItem> CartItems { get; set; }
    }
}
