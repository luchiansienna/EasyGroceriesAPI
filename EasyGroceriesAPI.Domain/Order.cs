using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGroceriesAPI.Domain;

public class Order
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OrderId { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual ICollection<OrderItem> Items { get; set; }

    [ForeignKey("CustomerId")]
    public virtual Customer Customer { get; set; }

    [ForeignKey("AddressId")]
    public virtual Address Address { get; set; }

    public double TotalPrice { get; set; }

    public Boolean HasOrderLoyaltyDiscountApplied { get; set; }

    public Order()
    {
        this.Items = new HashSet<OrderItem>();
        this.Customer = new Customer();
        this.Address = new Address();
    }

}

