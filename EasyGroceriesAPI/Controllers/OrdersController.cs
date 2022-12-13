using Microsoft.AspNetCore.Mvc;
using EasyGroceriesAPI.Domain;
using EasyGroceriesAPI.DataAccess;
using Microsoft.AspNetCore.Cors;
using EasyGroceriesAPI.DTO;
using AutoMapper;
using EasyGroceriesAPI.Business;

namespace EasyGroceriesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{

    private IUnitOfWork _unitOfWork;
    private IOrderProcessor _orderProcessor;
    private readonly IMapper _mapper;

    public OrdersController(IUnitOfWork unitOfWork, IMapper mapper, IOrderProcessor orderProcessor)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _orderProcessor = orderProcessor;
    }

    [HttpPost(Name = "PostOrder")]
    public async Task<ActionResult<OrderDto>> Post(OrderDto order)
    {
        try
        {
            if (order == null)
                return BadRequest();

            var orderDB = _mapper.Map<Order>(order);
            await _orderProcessor.AddOrder(orderDB);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new employee record: Error message:" + ex.Message);
        }
    }
}

