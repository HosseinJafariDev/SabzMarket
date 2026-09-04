using AutoMapper;
using SabzMarket.Application.UseCases.Auth.SignUp;
using SabzMarket.Domain.Entities.Users;

namespace SabzMarket.Application.UseCases.Auth.Mappers
{
    public class SignUpProfile : Profile
    {
        public SignUpProfile()
        {
            CreateMap<SignUpInputDto, User>()
                .ForMember(x => x.PasswordHash, opt => opt.MapFrom(src => src.Password));
        }
    }
}