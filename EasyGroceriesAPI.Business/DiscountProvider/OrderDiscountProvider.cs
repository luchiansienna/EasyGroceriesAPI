using System;
namespace EasyGroceriesAPI.Business;

public class OrderDiscountProvider : IOrderDiscountProvider
{
	public double GetDiscount()
	{
		return (double)20/100;
	}
}


