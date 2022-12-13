using System;
using System.Threading.Tasks;
using EasyGroceriesAPI.Business.UnitTests.MockData;
using EasyGroceriesAPI.Business.Validation;
using EasyGroceriesAPI.Domain;
using Moq;
using NUnit.Framework;
using Moq.EntityFrameworkCore;
using EasyGroceriesAPI.DataAccess;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EasyGroceriesAPI.Business.UnitTests;
[TestFixture]
public class OrderProcessorTests
{
    private OrderProcessor _orderProcessor;
    private Mock<IUnitOfWork> _unitOfWork;
    private IValidatorOrderProcessor _validatorOrderProcessor;
    private IOrderDiscountProvider _discountProvider;
    private Mock<EasyGroceriesDBContext> _context;
    private Mock<GenericRepository<Order>> _orderRepository;
    private Mock<GenericRepository<OrderItem>> _orderItemRepository;
    [SetUp]
    public void SetUp()
    {
        _unitOfWork = new Mock<IUnitOfWork>();
        _context = new Mock<EasyGroceriesDBContext>();
        _validatorOrderProcessor = new ValidatorOrderProcessor();
        _discountProvider = new OrderDiscountProvider();
        _orderProcessor = new OrderProcessor(_unitOfWork.Object, _validatorOrderProcessor, _discountProvider);
        _context.Setup(mock => mock.Set<Order>()).ReturnsDbSet(new List<Order>() { });
        _context.Setup(mock => mock.Set<OrderItem>()).ReturnsDbSet(new List<OrderItem>() { });
        _orderRepository = new Mock<DataAccess.GenericRepository<Order>>(_context.Object);
        _orderItemRepository = new Mock<DataAccess.GenericRepository<OrderItem>>(_context.Object);
        _unitOfWork.Setup(mock => mock.OrderRepository).Returns(_orderRepository.Object);
        _unitOfWork.Setup(mock => mock.OrderItemRepository).Returns(_orderItemRepository.Object);
        _unitOfWork.Setup(mock => mock.SaveAsync());

    }

    [Test]
    public void PassEmptyOrder()
    {

        var ioe = Assert.ThrowsAsync<Exception>(async () => await _orderProcessor.AddOrder(MockedOrders.EmptyOrder));
        Assert.That(ioe.Message, Is.EqualTo("Order must have a City"));

    }

    [Test]
    public void PassSimpleOrderWithNoItems()
    {
        var ioe = Assert.ThrowsAsync<Exception>(async () => await _orderProcessor.AddOrder(MockedOrders.SimpleOrderWithNoItems));
        Assert.That(ioe.Message, Is.EqualTo("Order must have items"));

    }

    [Test]
    public void PassSimpleOrderWithNoCity()
    {
        var ioe = Assert.ThrowsAsync<Exception>(async () => await _orderProcessor.AddOrder(MockedOrders.SimpleOrderWithNoCity));
        Assert.That(ioe.Message, Is.EqualTo("Order must have a City"));

    }

    [Test]
    public void PassSimpleOrderWithNoCountryCode()
    {
        var ioe = Assert.ThrowsAsync<Exception>(async () => await _orderProcessor.AddOrder(MockedOrders.SimpleOrderWithNoCountryCode));
        Assert.That(ioe.Message, Is.EqualTo("Order must have a CountryCode"));

    }

    [Test]
    public void PassSimpleOrderWithNoPostCode()
    {
        var ioe = Assert.ThrowsAsync<Exception>(async () => await _orderProcessor.AddOrder(MockedOrders.SimpleOrderWithNoPostCode));
        Assert.That(ioe.Message, Is.EqualTo("Order must have a PostCode"));

    }

    [Test]
    public void PassSimpleOrderWithNoStreet()
    {
        var ioe = Assert.ThrowsAsync<Exception>(async () => await _orderProcessor.AddOrder(MockedOrders.SimpleOrderWithNoStreet));
        Assert.That(ioe.Message, Is.EqualTo("Order must have a Street"));

    }

    [Test]
    public void PassSimpleOrderWithNoTotal()
    {

        var ioe = Assert.ThrowsAsync<Exception>(async () => await _orderProcessor.AddOrder(MockedOrders.SimpleOrderWithNoTotalPrice));
        Assert.That(ioe.Message, Is.EqualTo("Total price must be a non zero positive number"));

    }

    [Test]
    public void PassSimpleOrderWithNoItems2()
    {

        var ioe = Assert.ThrowsAsync<Exception>(async () => await _orderProcessor.AddOrder(MockedOrders.SimpleOrderWithNoItems2));
        Assert.That(ioe.Message, Is.EqualTo("Order must have items"));

    }

    [Test]
    public void PassSimpleOrderWithItemsThatAreEmpty()
    {

        var ioe = Assert.ThrowsAsync<Exception>(async () => await _orderProcessor.AddOrder(MockedOrders.SimpleOrderWithItemsThatAreEmpty));
        Assert.That(ioe.Message, Is.EqualTo("Each item in order must have quantity as a positive non zero number"));

    }


    [Test]
    public void PassSimpleOrderWithItems()
    {
        var internalEntityEntry = new InternalEntityEntry(
            new Mock<IStateManager>().Object,
            new RuntimeEntityType("T", typeof(Object), false, null, null, null, ChangeTrackingStrategy.Snapshot, null, false, null),
            MockedOrders.SimpleOrderWithItems);

        var entityEntry = new Mock<EntityEntry<Order>>(internalEntityEntry);

        _context.Setup(mock => mock.Entry(MockedOrders.SimpleOrderWithItems)).Returns(entityEntry.Object); // new Mock<Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Order>>(mockInternalEntry.Object).Object);

        var result = _orderProcessor.AddOrder(MockedOrders.SimpleOrderWithItems).Result;
        _orderRepository.Verify(mock => mock.Insert(MockedOrders.SimpleOrderWithItems), Times.Once);

    }


}
