using System.Linq.Expressions;
using EasyGroceriesAPI.Business.Validation;
using EasyGroceriesAPI.Domain;

namespace EasyGroceriesAPI.Business;

public class ValidatorOrderProcessor : IValidatorOrderProcessor
{
    public void ValidateOrder(Order order)
    {
        if (order.Customer == null) throw new Exception("Order must have a customer");
        
        if (order.Address == null) throw new Exception("Order must have a address");
        if (string.IsNullOrEmpty(order.Address.City)) throw new Exception("Order must have a City");
        if (string.IsNullOrEmpty(order.Address.CountryCode)) throw new Exception("Order must have a CountryCode");
        if (string.IsNullOrEmpty(order.Address.PostCode)) throw new Exception("Order must have a PostCode");
        if (string.IsNullOrEmpty(order.Address.Street)) throw new Exception("Order must have a Street");
        if (order.TotalPrice <= 0) throw new Exception("Total price must be a non zero positive number");
        if (order.Items == null || order.Items.Count() == 0) throw new Exception("Order must have items");
        foreach(var item in order.Items)
        {
            if (item.Quantity <= 0) throw new Exception("Each item in order must have quantity as a positive non zero number");
            if (item.UnitPrice <= 0) throw new Exception("Each item in the order must have the unit price as a positive non zero ");
            if (item.TotalPrice <= 0) throw new Exception("Each item in the order must have the total price as a positive non zero ");
        }
        var loyaltyMembershipItems = order.Items.Where(item => item.IsLoyaltyMembershipItem);
        if (loyaltyMembershipItems.Count() > 1) throw new Exception("Order cannot have more than 1 Loyalty Membership Item. Currently it has " + loyaltyMembershipItems);
        var quantityLM = loyaltyMembershipItems.FirstOrDefault().Quantity;
        if (quantityLM != 1 && quantityLM != 0)
            throw new Exception("Quantity of Loyalty Membership can only be 0 or 1");


    }
}