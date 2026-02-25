using AutoMapper;
using SabzMarket.Application.UseCases.CartItems.AddToCart;
using SabzMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.CartItems.Mappers
{
    public class CartItemProfile : Profile
    {
        public CartItemProfile()
        {
            CreateMap<AddToCartInputDTO, CartItem>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
