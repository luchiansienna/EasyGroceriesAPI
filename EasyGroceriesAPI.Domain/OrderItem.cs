using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGroceriesAPI.Domain;
public class OrderItem
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? OrderItemId { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public Boolean IsLoyaltyMembershipItem { get; set; }

    public int Quantity { get; set; }

    public double UnitPrice { get; set; }

    public double TotalPrice { get; set; }

}

