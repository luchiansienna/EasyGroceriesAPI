using System;
using EasyGroceriesAPI.Domain;

namespace EasyGroceriesAPI.DataAccess;

public class UnitOfWork : IUnitOfWork
{
    private readonly EasyGroceriesDBContext _context;
    private GenericRepository<Product> productRepository;
    private GenericRepository<Order> orderRepository;
    private GenericRepository<Address> addressRepository;
    private GenericRepository<Customer> customerRepository;
    private GenericRepository<OrderItem> orderItemRepository;

    public UnitOfWork(EasyGroceriesDBContext context)
    {
        _context = context;
    }
    public GenericRepository<Product> ProductRepository
    {
        get
        {

            if (this.productRepository == null)
            {
                this.productRepository = new GenericRepository<Product>(_context);
            }
            return productRepository;
        }
    }

    public GenericRepository<Order> OrderRepository
    {
        get
        {

            if (this.orderRepository == null)
            {
                this.orderRepository = new GenericRepository<Order>(_context);
            }
            return orderRepository;
        }
    }

    public GenericRepository<Address> AddressRepository
    {
        get
        {

            if (this.addressRepository == null)
            {
                this.addressRepository = new GenericRepository<Address>(_context);
            }
            return addressRepository;
        }
    }

    public GenericRepository<Customer> CustomerRepository
    {
        get
        {

            if (this.customerRepository == null)
            {
                this.customerRepository = new GenericRepository<Customer>(_context);
            }
            return customerRepository;
        }
    }

    public GenericRepository<OrderItem> OrderItemRepository
    {
        get
        {

            if (this.orderItemRepository == null)
            {
                this.orderItemRepository = new GenericRepository<OrderItem>(_context);
            }
            return orderItemRepository;
        }
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
