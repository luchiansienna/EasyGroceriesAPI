using EasyGroceriesAPI.DataAccess;
using EasyGroceriesAPI.Domain;

public interface IUnitOfWork
{
    GenericRepository<Product> ProductRepository { get; }
    GenericRepository<Address> AddressRepository { get; }
    GenericRepository<Customer> CustomerRepository { get; }
    GenericRepository<Order> OrderRepository { get; }
    GenericRepository<OrderItem> OrderItemRepository { get; }
    Task<int> SaveAsync();
    void Dispose();
}