using AutoMapper;
using SabzMarket.Application.UseCases.Categories.GetCategory;
using SabzMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Categories.Mappers
{
    public class CategorieProfile : Profile
    {
        public CategorieProfile()
        {
            CreateMap<Categorie, GetAllCategoriesOutputDTO>();
        }
    }
}
