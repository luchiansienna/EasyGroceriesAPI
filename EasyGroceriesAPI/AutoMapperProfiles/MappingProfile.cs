using System;
using AutoMapper;
using EasyGroceriesAPI.Domain;
using EasyGroceriesAPI.DTO;

namespace EasyGroceriesAPI.AutoMapperProfiles;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Address, AddressDto>().ReverseMap();
        CreateMap<Customer, CustomerDto>().ReverseMap();
        CreateMap<Order, OrderDto>().ReverseMap();
        CreateMap<OrderItem, OrderItemDto>()
        .ReverseMap().ForMember(x => x.OrderItemId, opt => opt.Ignore());
        CreateMap<Product, ProductDto>().ReverseMap();

    }
}