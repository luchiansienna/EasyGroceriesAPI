using System;
using EasyGroceriesAPI.Domain;

namespace EasyGroceriesAPI.Business.Validation;
public interface IValidatorOrderProcessor
{
    void ValidateOrder(Order order);
}

