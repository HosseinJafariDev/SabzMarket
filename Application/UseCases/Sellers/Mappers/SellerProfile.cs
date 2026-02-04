using AutoMapper;
using SabzMarket.Application.UseCases.Sellers.CreateSeller;
using SabzMarket.Application.UseCases.Sellers.GetSeller;
using SabzMarket.Application.UseCases.Sellers.UpdateSeller;
using SabzMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Sellers.Mappers
{
    public class SellerProfile : Profile
    {
        public SellerProfile()
        {
            CreateMap<CreateSellerInputDTO, Seller>()
                .ForMember(dest => dest.UserId, opt => opt.Ignore())
                .ForMember(dest => dest.Users, opt => opt.Ignore());

            CreateMap<Seller, GetSellerOutputDTO>()
            .ForMember(dest => dest.FirstName,
                opt => opt.MapFrom(src => src.Users!.FirstName))
            .ForMember(dest => dest.LastName,
                opt => opt.MapFrom(src => src.Users!.LastName))
            .ForMember(dest => dest.Email,
                opt => opt.MapFrom(src => src.Users!.Email))
            .ForMember(dest => dest.Phone,
                opt => opt.MapFrom(src => src.Users!.Phone))
            .ForMember(dest => dest.Username,
                opt => opt.MapFrom(src => src.Users!.UserName))
            .ForMember(dest => dest.Password,
                opt => opt.MapFrom(src => src.Users!.Password));

            CreateMap<SellerUpdateInputDTO, Seller>()
                .ForMember(dest => dest.Users, opt => opt.Ignore());

            CreateMap<SellerUpdateInputDTO, User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.NewUsername));
        }
    }
}
