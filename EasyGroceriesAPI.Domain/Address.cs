using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGroceriesAPI.Domain;
public class Address
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AddressId { get; set; }

    public string Street { get; set; }

    public string City { get; set; }

    public string PostCode { get; set; }

    public string CountryCode { get; set; }
}
