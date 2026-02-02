using AutoMapper;
using SabzMarket.Application.UseCases.Auth.UseCases.SignUp;
using SabzMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Auth.Mappers
{
    public class SignUpProfile:Profile
    {
        public SignUpProfile()
        {
            CreateMap<SignUpInputDTO,User>();
        }
    }
}
