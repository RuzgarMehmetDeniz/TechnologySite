using Microsoft.AspNetCore.Identity;

public class Order
{
    public int OrderID { get; set; }
    public string UserID { get; set; }
    public IdentityUser User { get; set; }


    public DateTime CreatedDate { get; set; }
    public decimal TotalPrice { get; set; }

    public ICollection<OrderItem> OrderItems { get; set; }
}
