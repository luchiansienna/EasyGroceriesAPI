using System;
using System.ComponentModel.DataAnnotations;

namespace EasyGroceriesAPI.DTO;

public class CustomerDto
{
    public int customerId { get; set; }

	public string firstName { get; set; }

	public string lastName { get; set; }

	public string email { get; set; }

	public Boolean hasLoyaltyMembership { get; set; }
}


