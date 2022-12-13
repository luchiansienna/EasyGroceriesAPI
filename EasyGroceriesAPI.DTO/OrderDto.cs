using System.ComponentModel.DataAnnotations;

namespace EasyGroceriesAPI.DTO;

public class OrderDto
{
    public int orderId { get; set; }

    public DateTime createdDate { get; set; }

    public List<OrderItemDto> items { get; set; }

    public CustomerDto customer { get; set; }

    public AddressDto address { get; set; }

    public double totalPrice { get; set; }

    public Boolean hasOrderLoyaltyDiscountApplied { get; set; }

    public OrderDto()
    {
        items = new List<OrderItemDto>();
    }
}

