using System.Linq.Expressions;
using EasyGroceriesAPI.Business.Validation;
using EasyGroceriesAPI.Domain;

namespace EasyGroceriesAPI.Business;

public class OrderProcessor : IOrderProcessor
{
    private IUnitOfWork _unitOfWork;
    private double discount;
    private IValidatorOrderProcessor _validatorOrderProcessor;
    private IOrderDiscountProvider _discountProvider;
    public OrderProcessor(IUnitOfWork unitOfWork, IValidatorOrderProcessor validatorOrderProcessor, IOrderDiscountProvider discountProvider)
    {
        _unitOfWork = unitOfWork;
        _validatorOrderProcessor = validatorOrderProcessor;
        _discountProvider = discountProvider;
    }

    private Order CalculateDiscountsForEachItem(Order order)
    {
        var discount = _discountProvider.GetDiscount();
        // Discount applied for each product line excluding the Loyalty Membership card
        if (order.Items.Any(item => item.IsLoyaltyMembershipItem))
            foreach (OrderItem orderItem in order.Items)
                if (!orderItem.IsLoyaltyMembershipItem)
                {
                    orderItem.UnitPrice = Math.Round(orderItem.UnitPrice * ((double)1 - discount), 2);
                    orderItem.TotalPrice = Math.Round(orderItem.TotalPrice * ((double)1 - discount), 2);
                }
        return order;
    }
    public async Task<int> AddOrder(Order order)
    {
        _validatorOrderProcessor.ValidateOrder(order);
       
        order = CalculateDiscountsForEachItem(order);
        _unitOfWork.OrderRepository.Insert(order);
        return await _unitOfWork.SaveAsync();
    }

    public async Task<int> UpdateOrder(Order order)
    {
        _validatorOrderProcessor.ValidateOrder(order);

        order = CalculateDiscountsForEachItem(order);
        _unitOfWork.OrderRepository.Update(order);
        return await _unitOfWork.SaveAsync();
    }

    public async Task<int> DeleteOrder(Order order)
    {
        _unitOfWork.OrderRepository.Delete(order);
        return await _unitOfWork.SaveAsync();
    }

    public Order GetOrder(int orderId)
    {    
        return _unitOfWork.OrderRepository.GetByID(orderId);
    }

    public IEnumerable<Order> GetOrder(Expression<Func<Order, bool>> filter = null,
        Func<IQueryable<Order>, IOrderedQueryable<Order>> orderBy = null,
        string includeProperties = "")
    {
        return _unitOfWork.OrderRepository.Get(filter, orderBy, includeProperties);
    }
}
