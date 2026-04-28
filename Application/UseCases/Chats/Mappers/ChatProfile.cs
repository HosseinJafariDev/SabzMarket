using AutoMapper;
using SabzMarket.Application.UseCases.Chats.GetMessage;
using SabzMarket.Application.UseCases.Chats.SendMessage;
using SabzMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Chats.Mappers
{
    public class ChatProfile : Profile
    {
        public ChatProfile()
        {
            CreateMap<Chat, GetMessageOutputDTO>();
            CreateMap<SendMessageInputDTO, Chat>();
        }
    }
}
