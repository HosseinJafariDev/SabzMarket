using AutoMapper;
using SabzMarket.Application.UseCases.CartItems.GetCartItem;
using SabzMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Orders.Mappers
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<GetCartItemByFarmerIdOutputDTO, Order>()
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(x => x.AddedDate));

            CreateMap<GetCartItemByFarmerIdOutputDTO, OrderDetail>()
                .ForMember(dest => dest.Price, opt => opt.MapFrom(x => x.ProductPrice))
                .ForMember(dest => dest.Number, opt => opt.MapFrom(x => x.Quantity));
        }
    }
}
