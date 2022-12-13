using System.ComponentModel.DataAnnotations;


namespace EasyGroceriesAPI.DTO;

public class OrderItemDto
{
    public int orderItemId { get; set; }

    public int orderId { get; set; }

    public int productId { get; set; }

    public Boolean isLoyaltyMembershipItem { get; set; }

    public int quantity { get; set; }

    public double unitPrice { get; set; }

    public double totalPrice { get; set; }
}

