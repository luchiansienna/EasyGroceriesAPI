using System;
using EasyGroceriesAPI.DataAccess;
using System.Linq.Expressions;
using EasyGroceriesAPI.Domain;

namespace EasyGroceriesAPI.Business;
public interface IOrderProcessor
{
    Task<int> AddOrder(Order order);
    Task<int> UpdateOrder(Order order);
    Task<int> DeleteOrder(Order order);

    Order GetOrder(int orderId);

    IEnumerable<Order> GetOrder(Expression<Func<Order, bool>> filter = null,
        Func<IQueryable<Order>, IOrderedQueryable<Order>> orderBy = null,
        string includeProperties = "");
}

