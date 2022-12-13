using System;
using System.ComponentModel.DataAnnotations;
namespace EasyGroceriesAPI.DTO;

public class AddressDto
{
    public int addressId { get; set; }

    public string street { get; set; }

    public string city { get; set; }

    public string postCode { get; set; }

    public string countryCode { get; set; }
}
