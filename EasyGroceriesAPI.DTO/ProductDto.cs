using System.ComponentModel.DataAnnotations;

namespace EasyGroceriesAPI.DTO;

public class ProductDto
{
    public int productId { get; set; }

    public string name { get; set; }

    public string? description { get; set; }

    public double price { get; set; }

}

