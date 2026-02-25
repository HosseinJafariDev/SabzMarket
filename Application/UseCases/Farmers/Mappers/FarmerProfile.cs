using AutoMapper;
using SabzMarket.Application.UseCases.Farmers.CreateFarmer;
using SabzMarket.Application.UseCases.Farmers.UpdateFarmer;
using SabzMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Farmers.Mappers
{
    public class FarmerProfile : Profile
    {
        public FarmerProfile()
        {
            CreateMap<CreateFarmerInputDTO, Farmer>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.UserId, opt => opt.Ignore());

            CreateMap<UpdateFarmerInputDTO, Farmer>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.FarmerId))
                .ForMember(dest => dest.DataBuilt, opt => opt.Ignore())
                .ForMember(dest => dest.LandArea, opt => opt.Ignore())
                .ForMember(dest => dest.NationalCode, opt => opt.Ignore())
                .ForMember(dest => dest.CodParvaneBHB, opt => opt.Ignore());

            CreateMap<UpdateFarmerInputDTO, User>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.NewUsername));
        }
    }
}
