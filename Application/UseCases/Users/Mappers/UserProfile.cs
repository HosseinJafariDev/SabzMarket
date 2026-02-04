using AutoMapper;
using SabzMarket.Application.UseCases.Users.GetUser;
using SabzMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Users.Mappers
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<User,GetUserByUserNameOutputDTO>();
            CreateMap<GetUserByUserNameOutputDTO, User>();
        }
    }
}
