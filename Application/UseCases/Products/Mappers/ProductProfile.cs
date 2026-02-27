using AutoMapper;
using SabzMarket.Application.UseCases.Products.CreateProduct;
using SabzMarket.Application.UseCases.Products.GetProduct;
using SabzMarket.Application.UseCases.Products.UpdateProduct;
using SabzMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Products.Mappers
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductInputDTO, Product>()
                .ForMember(dest=>dest.IsDeleted,opt=>opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Product, GetProductOutputDTO>();

            CreateMap<UpdateProductInputDTO, Product>()
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore());
        }
    }
}
