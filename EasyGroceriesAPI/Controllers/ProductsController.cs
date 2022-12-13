using Microsoft.AspNetCore.Mvc;
using EasyGroceriesAPI.Domain;
using EasyGroceriesAPI.DataAccess;
using Microsoft.AspNetCore.Cors;
using AutoMapper;
using EasyGroceriesAPI.DTO;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;

namespace EasyGroceriesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProductsController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet(Name = "GetProducts")]
    public async Task<ActionResult<IEnumerable<ProductDto>>> Get()
    {
        try
        {
            var result = _mapper.Map<IEnumerable<ProductDto>>(_unitOfWork.ProductRepository.Get());

            if (result.Any())
            {
                return Ok(result);
            }

            return NotFound();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error retrieving data from the database:" + ex.Message);
        }
    }
}

